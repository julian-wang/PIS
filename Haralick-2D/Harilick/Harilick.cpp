// Harilick.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include <iostream>
#include <fstream>
#include <string.h>
#include <stdio.h>

#include "ppgm.h"
#include "CVIPtexture.h"
#include "IdealArrBuilder.h"
#include "CFindfile.h"

//#define WIN32 1
//#define cimg_OS 2
//#define cimg_display_type 2
//#include "CImg.h"
//using namespace cimg_library;

#define MAX_PATH 256

using namespace std;

BOOL IsRoot(LPCTSTR lpszPath);
void function(LPCTSTR lpszPath, LPCTSTR lpsavePath);
void HProcess(LPCTSTR lpszPath, LPCTSTR lpsavePath);

int _tmain(int argc, _TCHAR* argv[])
{

	TCHAR lpfindPath[MAX_PATH];
	lstrcpy(lpfindPath, L"D:\\pictest\\in");
	TCHAR lpoutPath[MAX_PATH];
	lstrcpy(lpoutPath, L"D:\\pictest\\out");
	TCHAR lpfilename[MAX_PATH];
	lstrcpy(lpfilename, lpoutPath);
	lstrcat(lpfilename, L"\\HaralickFeatures.txt");
	std::wofstream outfilehead;
	outfilehead.open(lpfilename, std::ios::app);

	if (outfilehead.is_open())
	{	
		outfilehead<< "Filename: ASM[0] contrast[0] correlation[0] variance[0] IDM[0] sum_avg[0] sum_var[0] sum_entropy[0] entropy[0] diff_var[0] diff_entropy[0] meas_corr1[0] meas_corr2[0] max_corr_coef[0]" << " ";
		outfilehead<< "ASM[45] contrast[45] correlation[45] variance[45] IDM[45] sum_avg[45] sum_var[45] sum_entropy[45] entropy[45] diff_var[45] diff_entropy[45] meas_corr1[45] meas_corr2[45] max_corr_coef[45]" << " ";
		outfilehead<< "ASM[90] contrast[90] correlation[90] variance[90] IDM[90] sum_avg[90] sum_var[90] sum_entropy[90] entropy[90] diff_var[90] diff_entropy[90] meas_corr1[90] meas_corr2[90] max_corr_coef[90]" << " ";
		outfilehead<< "ASM[135] contrast[135] correlation[135] variance[135] IDM[135] sum_avg[135] sum_var[135] sum_entropy[135] entropy[135] diff_var[135] diff_entropy[135] meas_corr1[135] meas_corr2[135] max_corr_coef[135]" << " ";
		outfilehead<< "ASM[mean] contrast[mean] correlation[mean] variance[mean] IDM[mean] sum_avg[mean] sum_var[mean] sum_entropy[mean] entropy[mean] diff_var[mean] diff_entropy[mean] meas_corr1[mean] meas_corr2[mean] max_corr_coef[mean]" << " ";
		outfilehead<< "ASM[arrange] contrast[arrange] correlation[arrange] variance[arrange] IDM[arrange] sum_avg[arrange] sum_var[arrange] sum_entropy[arrange] entropy[arrange] diff_var[arrange] diff_entropy[arrange] meas_corr1[arrange] meas_corr2[arrange] max_corr_coef[arrange]" <<std::endl;
	}
	else std::cout << "Unable to open file";	

	outfilehead.close();

	function(lpfindPath,lpoutPath);

	return 0;
}

BOOL IsRoot(LPCTSTR lpszPath)
{
	TCHAR szRoot[4];
	wsprintf(szRoot, L"%c:\\", lpszPath[0]);
	return (lstrcmp(szRoot, lpszPath)==0);
}

void function(LPCTSTR lpszPath, LPCTSTR lpsavePath)
{
	TCHAR szFind [MAX_PATH];
	lstrcpy (szFind, lpszPath);
	if (!IsRoot(szFind))
	{
		lstrcat(szFind, L"\\");
	}
	lstrcat(szFind, L"*.*");
	WIN32_FIND_DATA wfd;
	HANDLE hFind = FindFirstFile(szFind, &wfd);
	if(INVALID_HANDLE_VALUE==hFind)
	{
		return;
	}
	do
	{
		TCHAR lppathname [MAX_PATH];
		if(lstrcmp(wfd.cFileName, _T(".")) == 0 || lstrcmp(wfd.cFileName, _T(".."))==0)
			continue;
		if(wfd.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
		{
			TCHAR szFile[MAX_PATH];
			if(IsRoot(lpszPath))
				wsprintf(szFile, L"%s\\%s", lpszPath, wfd.cFileName);
			else
				wsprintf(szFile, L"%s\\%s", lpszPath, wfd.cFileName);
			function(szFile, lpsavePath);
		}
		else
		{			
			lstrcpy(lppathname, lpszPath);
			lstrcat(lppathname, L"\\");
			lstrcat(lppathname, wfd.cFileName);
			HProcess(lppathname, lpsavePath);
		}
	}while(FindNextFile(hFind, &wfd));
	FindClose(hFind);
}

void HProcess(LPCTSTR lpszPath, LPCTSTR lpsavePath)
{

	std::ifstream inrawf;
	inrawf.open(lpszPath);
	//inrawf.open(lpszPath, std::ios::in|std::ios::binary);
	if(!inrawf)
	{
		return;
	}

	char width[256];
	inrawf.getline(width,256,'\t');
	char height[256];
	inrawf.getline(height,256,'\t');
	char depth[256];
	inrawf.getline(depth,256,'\t');

	const int row = atoi(height);
	const int col = atoi(width);
	gray** grayscales = new gray* [row];
	char tmp[10];
	for(int i=0;i<row;i++){
		grayscales[i] = new gray[col];
		for(int j=0;j<col;j++){
			inrawf.getline(tmp, 10, '\t');
			grayscales[i][j] = atoi(tmp);
		}
		/*inrawf.getline(tmp, 10, '\n');
		grayscales[i][col-1] = atoi(tmp);*/
	}
	

	/*int nxyz[3];
	inrawf.read((char*)nxyz,sizeof(nxyz));

	float fxyz[3];
	inrawf.read((char*)fxyz, sizeof(fxyz));

	int ixylong = nxyz[0]*nxyz[1];
	int ixzlong = nxyz[0]*nxyz[2];
	int ilong = ixylong*nxyz[2];

	short* rawdata = new short [ilong];

	for(int ir=0; ir<ilong; ir++)
	{
	rawdata[ir] = 0;
	}
	inrawf.read((char*)rawdata,ilong*sizeof(short));

	inrawf.close();

	int imin = 1000;
	int imax = -1000;
	for(int ira=0; ira<ilong; ira++)
	{
	if(imin>rawdata[ira])
	{
	imin = rawdata[ira];
	}
	if(imax<rawdata[ira])
	{
	imax = rawdata[ira];
	}
	}

	if(imin<0||imax>255)
	{
	for(int iraw=0; iraw<ilong; iraw++)
	{
	rawdata[iraw] = rawdata[iraw];
	}
	}*/

	int d = 1;
	TEXTURE* texturesults;
	TEXTURE_FEATURE_MAP texturemap;
	texturemap.ASM = 1;
	texturemap.contrast = 1;
	texturemap.correlation = 1;
	texturemap.diff_entropy = 1;
	texturemap.diff_var = 1;
	texturemap.entropy = 1;
	texturemap.IDM = 1;
	texturemap.max_corr_coef = 1;
	texturemap.meas_corr1 = 1;
	texturemap.meas_corr2 = 1;
	texturemap.sum_avg = 1;
	texturemap.sum_entropy = 1;
	texturemap.sum_var = 1;
	texturemap.variance = 1;

	////gray* grayslice = new gray [nxyz[1]];
	////for(int ig=0; ig<nxyz[1]; ig++)
	////{
	////	grayslice[ig] = 0;
	////}
	//int ixzl = (nxyz[0]+2)*nxyz[2];

	//size_t sizes[] = { ixzl, nxyz[1] }; //2 is the highest dimension.
	//gray** grayscales = IdealArrBuilder<gray, 2>::inew(sizes) ;
	//
	///*gray** grayscales = new gray*[ixzl];
	//for(int igz=0; igz<ixzl; igz++)
	//{
	//	grayscales[igz] = new gray [nxyz[1]]();
	//}*/
	////std::ofstream testfile ("D:\\test\\grayscales.txt");
	////if (testfile.is_open())
	////{
	//for (int ia=0; ia<nxyz[0]; ia++)
	//{
	//	for(int ic=0; ic<nxyz[2]; ic++)
	//	{
	//		for(int ib=0; ib<nxyz[1]; ib++)
	//		{
	//			grayscales[ic*(nxyz[0]+2)+ia+1][ib] = rawdata[ic*ixylong+ib*nxyz[0]+ia];
	//			//testfile << rawdata[ic*ixylong+ib*nxyz[0]+ia]<< " "; 
	//			//testfile << (int)grayscales[ic*(nxyz[0]+2)+ia+1][ib]<< " " ;
	//		}
	//	}
	//	//testfile << std::endl;
	//}
	////}
	////else std::cout << "Unable to open file";	

	////testfile.close();

	texturesults = Extract_Texture_Features(d, grayscales, row, col, &texturemap);
	TCHAR lpname[MAX_PATH];
	lstrcpy(lpname, lpsavePath);
	lstrcat(lpname, L"\\HaralickFeatures.txt");
	std::wofstream outfile;
	outfile.open(lpname, std::ios::app);

	if (outfile.is_open())
	{	
		outfile << lpszPath << " ";
		for(int iout=0; iout<6; iout++)
		{
			//���14��
			outfile << texturesults->ASM[iout] << " ";
			outfile << texturesults->contrast[iout] << " ";
			outfile << texturesults->correlation[iout] << " ";
			outfile << texturesults->variance[iout] << " ";
			outfile << texturesults->IDM[iout] << " ";
			outfile << texturesults->sum_avg[iout] << " ";
			outfile << texturesults->sum_var[iout] << " ";
			outfile << texturesults->sum_entropy[iout] << " ";
			outfile << texturesults->entropy[iout] << " ";
			outfile << texturesults->diff_var[iout] << " ";
			outfile << texturesults->diff_entropy[iout] << " ";			
			outfile << texturesults->meas_corr1[iout] << " ";
			outfile << texturesults->meas_corr2[iout] << " ";
			outfile << texturesults->max_corr_coef[iout] << " ";			
		}
		outfile << std::endl;
	}
	else std::cout << "Unable to open file";	

	outfile.close();
	IdealArrBuilder<gray, 2>::idelete(grayscales);


	return;
}