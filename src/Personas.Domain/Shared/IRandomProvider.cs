namespace Personas.Domain
{
    public interface IRandomProvider
    {
        int GetNumber(int minimun, int maximun);
    }
}