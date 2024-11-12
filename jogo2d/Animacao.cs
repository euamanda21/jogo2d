using Windows.ApplicationModel;

public class Animacao
{
    protected List<string> Animacao1 = new List<string>();
    protected List<string> Animacao2 = new List<string>();
    protected List<string> Animacao3 = new List<string>();
    protected bool Loop=true;
    protected int animacaoAtiva=1;
    bool parado=true;
    protected Image compImagem;
    public Animacao(Image a)
    {
        compImagem=a;
    }
    public void Stop()
    {
        parado=true;
    }
    public void Play()
    {
        parado=false;
    }
    public void SetAnimacaoAtiva(int a)
    {
        animacaoAtiva=a;
    }
    public void Desenhar()
    {
        if(parado)
           return;
        String nomeArquivo;
        int tamnhoanimacao;
        if(animacaoAtiva==1)
        {
            nomeArquivo=Animacao1[frameAtual];
            tamanhoAnimacao=Animacao1.Count;
        }
        else if (AnimacaoAtiva==2);
    }
}