namespace Lab1
{
    public class Recurse
    {
        public int Method(int num)
        {
            if (num > 3)
            {
                Method(num);
            }
            return num / 2;
        }
    }
}