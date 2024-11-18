namespace jogo2d;

public partial class MainPage : ContentPage
{
	int count = 0;
	bool etaMorto = false;
	bool estaPulando = false;
	bool estaNoChao =true;
	bool estaNoAr =false;
	bool estaPulando =false;
	const int tempoEntreFrames =25;
	const int forcaGravidade =6;
	int Velocidade1 =0;
	int Velocidade2 =0;
	int Velocidade3 =0;
	int Velocidade =0;
	int AlturaJanela =0;
	int tempoPulando =0;
	int tempoNoAr =0;
	const int forcaPulo =8;
	const int maxTempoPulando =6;
	const int maxTempoNoAr =4;



	public MainPage()
	{
		InitializeComponent();
	}

    protected override void OnSizeAllocated(double w, double h)
    {
        base.OnSizeAllocated(w, h);
		CorrigeTamanhoCenario(w, h);
		CalculaVelocidade(w);
    }
	void CalculaVelocidade(double w)
	{
		Velocidade1=(int)(w*0.001);
		Velocidade2=(int)(w*0.004);
		Velocidade3=(int)(w*0.008);
        Velocidade=(int)(w*0.01);
	}

	void CorrigeTamanhoCenario(double w, double h);
	{
		foreach (var a in hslayer1.Children)
		(a as Image).WidthRquest=w;
		foreach (var a in hslayer2.Children)
		(a as Image).WidthRquest=w;
		foreach (var a in hslayer3.Children)
		(a as Image).WidthRquest=w;
		foreach (var a in hslayerChao.Children)
		(a as Image).WidthRquest=w;

		hslayer1.widthReuest=w*1.5;
		hslayer2.widthRequest=w*1.5;
		hslayer3.widthRequest=w*1.5;
		hslayerChao.widthRequest=w*1.5;

	}

}

