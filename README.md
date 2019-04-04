# programming-practices
### 1. Memory allocation

  for x64:
  1. Amount of memory to allocate is 17665 MB
  2. Amount of single block of memory is 16368 MB

  for Any:
  1. Amount of memory to allocate is 2715 MB
  2. Amount of single block of memory is 1528 MB


### 2. HashTable

|              Method |       Mean |      Error |     StdDev |     Median | Ratio | Rank |
|-------------------- |-----------:|-----------:|-----------:|-----------:|------:|-----:|
|    ArrayWithoutGaps |   334.4 ms |  6.0484 ms |  4.7222 ms |   334.8 ms |  1.00 |    1 |
|                     |            |            |            |            |       |      |
|   ArrayWithBadItems |   267.0 ms |  0.8824 ms |  0.7369 ms |   267.0 ms |  1.00 |    1 |
|                     |            |            |            |            |       |      |
|   FirstHashFunction |   979.9 ms |  5.8536 ms |  4.8880 ms |   980.0 ms |  1.00 |    1 |
|                     |            |            |            |            |       |      |
| SecondtHashFunction | 1,031.8 ms | 26.0268 ms | 36.4860 ms | 1,012.3 ms |  1.00 |    1 |
|                     |            |            |            |            |       |      |
|   ThirdHashFunction |   999.3 ms |  7.5202 ms |  6.2797 ms |   999.1 ms |  1.00 |    1 |
  

