# recipies for porting examples


- convert `#define`
  - search: `#define (\w+)\s+(\w+)`
  - replace: `const int $1 = $2;`
- partial string replacement
  - search: `char (\w+)\[(\w+)\] = "(.+)\\0"`
  - replace `string $1 = $"$3"`