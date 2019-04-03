# programming-practices
1. Memory allocation

  for x64:
  1. Amount of memory to allocate is 17665 MB
  2. Amount of single block of memory is 16368 MB

  for Any:
  1. Amount of memory to allocate is 2715 MB
  2. Amount of single block of memory is 1528 MB


2. HashTable

  |              Method |     Mean |    Error |   StdDev | Ratio | Rank |
  |-------------------- |---------:|---------:|---------:|------:|-----:|
  |    ArrayWithoutGaps | 267.7 ms | 5.029 ms | 4.704 ms |  1.00 |    1 |
  |                     |          |          |          |       |      |
  |   ArrayWithBadItems | 267.8 ms | 2.639 ms | 2.203 ms |  1.00 |    1 |
  |                     |          |          |          |       |      |
  |   FirstHashFunction | 808.3 ms | 9.882 ms | 8.760 ms |  1.00 |    1 |
  |                     |          |          |          |       |      |
  | SecondtHashFunction | 790.0 ms | 1.740 ms | 1.453 ms |  1.00 |    1 |
  |                     |          |          |          |       |      |
  |   ThirdHashFunction | 800.2 ms | 6.462 ms | 5.396 ms |  1.00 |    1 |
  
  For adding to HashTable it should complete with O(1) for any hash function.
  But for SecondHashFunction we can see that it runs faster then others.
