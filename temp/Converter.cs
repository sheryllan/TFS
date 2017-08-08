public string intoToText(int value)
{
	Dictionary<int, char> int2charDict = new Dictionary<int, char>(){
		{0, '0'};
		{1, '1'};
		{2, '2'};
		{3, '3'};
		{4, '4'};
		{5, '5'};
		{6, '6'};
		{7, '7'};
		{8, '8'};
		{9, '9'};
	};

	int digit;
	List<char> charDigits = new List<char>();
	int divisor = value >=0 ? 10 : -10;

	while(value != 0)
	{
		digit = value % divisor;
		value = value / divisor;
		charDigits.Add(int2charDict[digit]);
	}

	if(value < 0)
		charDigits.Add('-');
	int count = charDigits.Count;
	for(int i = 0; i < count / 2; i++)
	{
		char temp = charDigits[i];
		charDigits[i] = charDigits[count - 1 - i];
		charDigits[count - 1 - i] = temp;
		
	}

	return new string(charDigits);

}

public void Test()
{
	int case1 = 0;
	int case2 = 1000000;
	int case3 = -2918;
	int case4 = int.MaxValue;
	int case5 = int.MinValue;
}