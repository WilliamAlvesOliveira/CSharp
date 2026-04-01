public class Aluno
{
    public string Nome;
    public double Nota1;
    public double Nota2;
    public double Nota3;

    public double Media()
    {
        return (Nota1 + Nota2 + Nota3) / 3;
    }

    public string Situacao()
    {
        if (Media() >= 6)
            return "Aprovado!";
        else
            return $"Reprovado! Faltaram {6 - Media():F2} pontos";
    }

    public override string ToString()
    {
        return $"Nome: {Nome}\nNotas: {Nota1:F2}, {Nota2:F2}, {Nota3:F2}\nNota Final: {Media():F2}";
    }
}