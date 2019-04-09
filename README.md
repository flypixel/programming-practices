# programming-practices
### 1. Memory allocation

  for x64:
  1. Amount of memory to allocate is 17665 MB
  2. Amount of single block of memory is 16368 MB

  for Any:
  1. Amount of memory to allocate is 2715 MB
  2. Amount of single block of memory is 1528 MB


### 2. HashTable
HashTable collection:
|              Method |    Mean |    Error |   StdDev | Ratio | Rank |
|-------------------- |--------:|---------:|---------:|------:|-----:|
|    ArrayWithoutGaps | 1.189 s | 0.0237 s | 0.0478 s |  1.00 |    1 |
|                     |         |          |          |       |      |
|   FirstHashFunction | 3.212 s | 0.0625 s | 0.0768 s |  1.00 |    1 |
|                     |         |          |          |       |      |
| SecondtHashFunction | 3.163 s | 0.0614 s | 0.0707 s |  1.00 |    1 |
|                     |         |          |          |       |      |
|   ThirdHashFunction | 2.778 s | 0.0550 s | 0.0540 s |  1.00 |    1 |

Updated with checking for existing keys. Benchmarks with bad keys worked too long, so it was skipped
