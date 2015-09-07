#pragma once
#define SUCCESS 1
#define PTRERR 0
template<class ElemType, size_t N_Dim>  
class IdealArrBuilder : public IdealArrBuilder<ElemType*, N_Dim-1> { 
public:
	typedef typename IdealArrBuilder<ElemType*, N_Dim-1>::FinalType FinalType;
protected: 
	template<class RandomAccessIter>
	static FinalType _bldCurDim(size_t sizec, RandomAccessIter size_beg, ElemType lower_dim) {  
		RandomAccessIter cur_iter = size_beg;
		size_t dim_size = 1; 
		for (size_t i = 0; i < sizec; ++i) 
			dim_size *= *(cur_iter++); 
		ElemType* higher_dim = new ElemType[dim_size];      
		higher_dim[0] = lower_dim; 
		for (size_t i = 1; i < dim_size; ++i) 
			higher_dim[i] = higher_dim[i - 1] + *(size_beg+sizec); 
		return IdealArrBuilder <ElemType*, N_Dim - 1>::_bldCurDim(sizec - 1, size_beg, higher_dim);  
	} 
	static ElemType _freeCurDim(FinalType ptr){ 
		ElemType * cur_ptr = IdealArrBuilder <ElemType*, N_Dim - 1>::_freeCurDim(ptr); 
		if (cur_ptr == NULL) return NULL; 
		ElemType lower_ptr = *cur_ptr; 
		delete [] cur_ptr;    
		return lower_ptr; 
	} 

public: 
	template<class RandomAccessIter>
	static FinalType ialloc(RandomAccessIter size_beg){ 
		RandomAccessIter cur_iter = size_beg;
		size_t dim_size = 1; 
		for (size_t i = 0; i < N_Dim; ++i)  
			dim_size *= *(cur_iter++); 
		ElemType* base = reinterpret_cast <ElemType*> (operator new (dim_size*sizeof(ElemType))); 
		return IdealArrBuilder <ElemType*, N_Dim - 1>::_bldCurDim(N_Dim - 1, size_beg, base); 
	} 
	template<class RandomAccessIter>
	static FinalType inew(RandomAccessIter size_beg)    {
		RandomAccessIter cur_iter = size_beg;
		size_t dim_size = 1; 
		for (size_t i = 0; i < N_Dim; ++i) 
			dim_size *= *(cur_iter++);     
		ElemType* base = new ElemType[dim_size]; 
		return IdealArrBuilder <ElemType*, N_Dim - 1>::_bldCurDim(N_Dim - 1, size_beg, base); 
	} 
	static int ifree(FinalType ptr)     {
		if (ptr == NULL) return PTRERR; 
		ElemType * cur_ptr = IdealArrBuilder <ElemType*, N_Dim - 1>::_freeCurDim(ptr); 
		if (cur_ptr == NULL) return PTRERR; 
		operator delete (cur_ptr); 
		return SUCCESS;
	} 
	static int idelete(FinalType ptr)    { 
		if (ptr == NULL) return PTRERR; 
		ElemType * cur_ptr = IdealArrBuilder <ElemType*, N_Dim - 1>::_freeCurDim(ptr); 
		if (cur_ptr == NULL) return PTRERR; 
		delete [] cur_ptr; 
		return SUCCESS; 
	} 


}; 
template <class ElemType> 
class IdealArrBuilder< ElemType, 0> { 

protected: 
	typedef ElemType FinalType;
	template<class RandomAccessIter>
	static FinalType _bldCurDim (size_t sizec, RandomAccessIter size_beg, ElemType lower_base) {  
		return lower_base;  
	} 
	static ElemType _freeCurDim(FinalType ptr){ 
		return ptr; 
	} 
}; 
