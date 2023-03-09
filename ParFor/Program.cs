// See https://aka.ms/new-console-template for more information
long sum = 0;
object o = new object();
long group_size = 100;
long count = 2000000000;
var po = new ParallelOptions();
po.MaxDegreeOfParallelism = 8;
Parallel.For(
    1L, 
    count / group_size + 1L, 
    po,
    i =>
{
    long from = (i - 1L) * group_size + 1L;
    long to = i * group_size + ((i == count / group_size) ? count % group_size : 0L);
    var s = 0L;
    for (long j = from; j <= to; j++)
    {
        s += j;
    }
    lock (o) { sum += s; }
});
Console.WriteLine(sum);