public bool hasRowOrColumnOfZeros(int[,] A)
{
	int rows = A.GetLength(0);
	int cols = A.GetLength(1);
	bool found = false;
	for(int i = 0; i < rows; i++)
	{
		bool frow = true;
		bool fcol = true;
		for(int j = 0; j < cols; j++)
		{
			frow = frow && (A[i, j] == 0); 
			fcol = fcol && (A[j, i] == 0);
		}
		found = found || frow || fcol;
		if(found)
			break;
	}

	return found;
}

public bool hasDiagonalOfZeros(int[,] A)
{
	int rows = A.GetLength(0);
	int cols = A.GetLength(1);
	bool found = false;
	for(int i = 0; i < rows; i++)
	{
		int i1 = i;
		int j1 = 0;
		int i2 = 0;		
		int j2 = i;
		int i3 = i;
		int j3 = rows - 1;
		int i4 = 0;
		int j4 = rows - 1 - i;

		bool f1 = true;
		bool f2 = true;
		bool f3 = true;
		bool f4 = true;
		while(i1 < rows && j2 < cols && i3 < rows && j4 >= 0)
		{
			f1 = f1 && A[i1++, j1++];
			f2 = f2 && A[i2++, j2++];
			f3 = f3 && A[i3++, j3--];
			f4 = f4 && A[i4++, j4--];

		}
		found = found || f1 || f2 || f3 || f4;	
		if(found)
			break;
	}
	return found;

}

public int[,] transpose(int[,] A)
{
	int rows = A.GetLength(0);
	int cols = A.GetLength(1);

	int[,] tp = new int[rows, cols];
	for(int i = 0; i < rows; i++)
	{
		for(int j = 0; j < cols; j++)
		{
			tp[i,j] = A[j,i];

		}

	}

}