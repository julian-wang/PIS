#include <windows.h>   
      
void SearchFile(TCHAR *lpDirectory, TCHAR *lpFileName);   
void FindFile(TCHAR *lpDirectory, TCHAR *lpFileName);   

typedef struct _DirList   
{   
    TCHAR Diretory[MAX_PATH];   
    struct _DirList *lpNext;   
}DirList;   
      
DirList *first = NULL;   
DirList *last = NULL;   
DirList *newList = NULL;   
      
// ���µ��ļ���·�����뵽������    
void AddList(TCHAR  *lpDiretory)   
{   
    newList = new DirList;   
    wsprintf(newList->Diretory, L"%s", lpDiretory);   
    newList->lpNext = NULL;   
    if (first == NULL)   
    {   
        first = newList;   
        last = newList;   
    }   
      
    else  
    {   
        last->lpNext = newList;   
        last = newList;   
    }   
           
}   
      
   
void SearchFile(TCHAR *lpDirectory, TCHAR *lpFileName)   
{   
    DirList NewList;   
    wsprintf(NewList.Diretory, L"%s", lpDirectory);   
    NewList.lpNext = NULL;   
    last = &NewList;   
    first = &NewList;   
      
    while(TRUE)   
    {   
        DirList *PFind;   
        if (first != NULL)   
        {   
            PFind = first;   
            first = first->lpNext;   
            FindFile(PFind->Diretory, lpFileName);   
        }   
      
        else  
        {   
            TCHAR ShowMsg[256] = L"Searching is ended����/n";   
            //DWORD dWriteFile;   
			//WriteFile(GetStdHandle(STD_OUTPUT_HANDLE), ShowMsg, strlen(ShowMsg), &dWriteFile, FALSE);   
            return ;   
        }   
    }   
      
    return ;   
}   
      
// �����ļ������ҵ����ļ��з�������   
void FindFile(TCHAR *lpDirectory, TCHAR *lpFileName)   
{   
    TCHAR FileRoad[MAX_PATH];   
    TCHAR DirRoad[MAX_PATH];   
    TCHAR FindedFile[MAX_PATH];   
    TCHAR FindedDir[MAX_PATH];   
    ZeroMemory(FileRoad, sizeof(FileRoad));   
    ZeroMemory(DirRoad, sizeof(DirRoad));   
    ZeroMemory(FindedFile, sizeof(FindedFile));   
    ZeroMemory(FindedDir, sizeof(FindedDir));   
      
    // �ҵ�lpDirectory�µ��ļ��м�������   
    wsprintf(DirRoad, L"%s\\*.*", lpDirectory);   
    WIN32_FIND_DATA findData;   
    HANDLE hFile;   
    hFile = FindFirstFile(DirRoad, &findData);   
    if (hFile != INVALID_HANDLE_VALUE)   
    {   
        do  
        {   
            // ������ļ��оͼ�������   
            if (findData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)   
            {   
                ZeroMemory(DirRoad, sizeof(DirRoad));   
                wsprintf(DirRoad, L"%s\\%s", lpDirectory, findData.cFileName);    
                // �����ļ�������   
                AddList(DirRoad);   
            }   
      
            else  
            {   
                continue;   
            }   
        }while(FindNextFile(hFile, &findData));   
    }   
      
    // �ҵ�lpDirectory�µ���lpFileNameΪ��ʽ���ļ�   
      
    wsprintf(FileRoad, L"%s\\%s", lpDirectory, lpFileName);   
    hFile = FindFirstFile(FileRoad, &findData);   
    DWORD dWriteFile;   
    if (hFile != INVALID_HANDLE_VALUE)   
    {   
        do  
        {   
            ZeroMemory(FileRoad, sizeof(FileRoad));   
            wsprintf(FileRoad, L"%s\\%s/n", lpDirectory, findData.cFileName);   
            //WriteFile(GetStdHandle(STD_OUTPUT_HANDLE), FileRoad, strlen(FileRoad), &dWriteFile, FALSE);   
        }while(FindNextFile(hFile, &findData));   
    }   
}  
