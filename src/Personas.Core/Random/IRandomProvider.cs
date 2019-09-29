namespace Personas.Core
{
    public interface IRandomProvider
    {
        int GetNumber(int minimun, int maximun);
    }
}
