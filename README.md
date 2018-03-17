# 3 funcs
函数式编程必备三函数(C#版)
## 1.Reduce:
将一组数据压缩/精简成一个数据(原数据中的其中一个)。
#### Example 1:
  ##### static bool max(int a, int b) { return a > b; }
  ##### var func1 = new Reduce函数<int>(max);
  ##### Console.WriteLine(Reduce<int>(func1, new int[]{ 1, 2, 3, 5, 100 })); //Output: 100
## 2.Map:
对一组数据重复操作后，得到另一组数据（与原数据长度相等）。
#### Example 2:
  ##### static int plus1(int a) { return a + 10; }
  ##### var func3 = new Map函数<int>(plus1);
  ##### var arr = Map<int>(func3, new int[] { 1, 2, 3, 4});
  ##### // arr: {11, 12, 13, 14}
## 3.Fold:
将一组数据压缩成一个数据(不属于原数据)。
#### Example 3:
  ##### static int plus2(int a, int b) { return a + b; }
  ##### var func4 = new Fold函数<int>(plus2);
  ##### Console.WriteLine(Fold<int>(func4, new int[]{1, 2, 3, 4, 5, 6, 7})); //Output: 29
##### 即求和，但得到的结果不属于原数据。
