#include "DataFile.h"
#include <fstream>
using namespace std;

DataFile::DataFile()
{
	recordCount = 0;
}

DataFile::~DataFile()
{
	Clear();
}

void DataFile::AddRecord(const char* imageFilename, const char* name, int age)
{
	Image i = LoadImage(imageFilename);

	Record* r = new Record;
	r->image = i;
	r->age = age;

	int length = strlen(name);
	r->name = new char[length + 1];
	strcpy_s(r->name, length, name);

	records.push_back(r);
	recordCount++;
}

Record* DataFile::GetRecord(int index)
{
	return records[index];
}

//--------------------------------------------------------
// This is the function that was used to save the data.
// No longer needed but left in so you can see the file format
//--------------------------------------------------------
//void DataFile::Save(const char* filename)
//{
//	ofstream outfile(filename, ios::binary);
//
//	int recordCount = records.size();
//	outfile.write((char*)&recordCount, sizeof(int));
//
//	for (int i = 0; i < recordCount; i++)
//	{		
//		Color* imgdata = GetImageData(records[i]->image);
//				
//		int imageSize = sizeof(Color) * records[i]->image.width * records[i]->image.height;
//		int nameSize = strlen(records[i]->name) + 1;
//		int ageSize = sizeof(int);
//
//		outfile.write((char*)&records[i]->image.width, sizeof(int));
//		outfile.write((char*)&records[i]->image.height, sizeof(int));
//		
//		outfile.write((char*)&nameSize, sizeof(int));
//		outfile.write((char*)&ageSize, sizeof(int));
//
//		outfile.write((char*)imgdata, imageSize);
//		outfile.write(records[i]->name, nameSize);
//		outfile.write((char*)&records[i]->age, ageSize);
//	}
//
//	outfile.close();
//}

//Replace the contents of this function with your load
void DataFile::Load(const char* filename)
{
	Clear();

	ifstream infile(filename, ios::binary);

	recordCount = 0;
	infile.read((char*)&recordCount, sizeof(int));

	for (int i = 0; i < recordCount; i++)
	{		
		int nameSize = 0;
		int ageSize = 0;
		int width = 0, height = 0, format = 0, imageSize = 0;

		infile.read((char*)&width, sizeof(int));
		infile.read((char*)&height, sizeof(int));

		imageSize = sizeof(Color) * width * height;

		infile.read((char*)&nameSize, sizeof(int));
		infile.read((char*)&ageSize, sizeof(int));

		char* imgdata = new char[imageSize];
		infile.read(imgdata, imageSize);

		Record* r = new Record();
		r->image = LoadImageEx((Color*)imgdata, width, height);
		r->name = new char[nameSize + 1];
		infile.read(r->name, nameSize);
		r->name[nameSize] = 0;
		infile.read((char*)&r->age, ageSize);

		records.push_back(r);

		delete[] imgdata;
	}

	infile.close();
}

void DataFile::Clear()
{
	for (int i = 0; i < (int)records.size(); i++)
	{
		delete records[i];
	}
	records.clear();
	recordCount = 0;
}