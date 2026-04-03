namespace Jokenpo.View.TableRender
{
    public class TableRender
    {
        private const int WIDTH = 45;
        private const int CONTENT_WIDTH = 43;
        public static void DrawLine(char caractere = '-')
        {
            Console.WriteLine($"|{new string(caractere, WIDTH)}|");
        }

        public static void JumpLine()
        {
            Console.WriteLine($"|{new string(' ', WIDTH)}|");
        }

        public static void Text(string text, string align = "c", string wrap = "wrap")
        {
            if (text.Trim() == "") return;

            string visibleText = System.Text.RegularExpressions.Regex.Replace(text, @"\x1B\[[0-9;]*m", "");

            text = text.Trim();
            if (visibleText.Length > CONTENT_WIDTH)
            {
                // Se não há espaços (palavra gigante)
                if (!text.Contains(" "))
                {
                    string parte = text.Substring(0, CONTENT_WIDTH - 1) + "-";
                    string resto = text.Substring(CONTENT_WIDTH - 1);
                    Text(parte, align);
                    Text(resto, align);
                    return;
                }
                else
                {
                    // Divide por palavras
                    string[] palavras = text.Split(' ');
                    string _linha = "";
                    foreach (string palavra in palavras)
                    {
                        if ((_linha + palavra).Length > CONTENT_WIDTH)
                        {
                            Text(_linha.Trim(), align);
                            _linha = palavra + " ";
                        }
                        else
                        {
                            _linha += palavra + " ";
                        }
                    }
                    if (_linha.Trim() != "")
                        Text(_linha.Trim(), align);
                    return;
                }
            }


            int spaces = CONTENT_WIDTH - visibleText.Length;
            string linha;

            switch (align.ToLower())
            {
                case "r":
                    linha = $"| {new string(' ', spaces)}{text} |";
                    break;

                case "l":
                    linha = $"| {text}{new string(' ', spaces)} |";
                    break;

                default:
                    int left = spaces / 2;
                    int right = spaces - left;
                    linha = $"| {new string(' ', left)}{text}{new string(' ', right)} |";
                    break;
            }

            if(wrap.ToLower() == "nowrap")
            {
                Console.Write(linha.Substring(0, linha.Length - 2));
            }
            else
            {
                Console.WriteLine(linha);
            }
               
        }


    }
}
