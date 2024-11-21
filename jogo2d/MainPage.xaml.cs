namespace jogo2d;

public partial class MainPage : ContentPage

{
	bool estaMorto=false;
	bool estaPulando=false;
	bool estaNoChao=true;
	bool estaNoAr=false;
	const int tempoEntreFrames=25;
	const int forcaGravidade=6;
	const int ForcaPulo=8;
	const int maxTempoPulando=6;
	const int maxTempoNoAr=4;
	int velocidade1=0;
	int velocidade2=0;
	int velocidade3=0;
	int velocidade=0;
	int largurJanela=0;
	int alturaJanela=0;
	int tempoPulando=0;
	int tempoNoAr=0;
	
	Player player;

	public MainPage()
	{
		InitializeComponent();
		player = new Player(imgcachorro);
		player.Run();
	}

    protected override void OnSizeAllocated(double w, double h)
    {
        base.OnSizeAllocated(w, h);
		CorrigeTamanhoCenario(w,h);
		CalculaVelocidade(w);
    }
	
	void OnGridTapped (object o, TappedEventArgs a)
	{
		if (estaNoChao)
			estaPulando=true;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		Desenha();
	}
	
	void CalculaVelocidade(double w)
	{
		velocidade1=(int)(w*0.001);
		velocidade2=(int)(w*0.004);
		velocidade3=(int)(w*0.008);
		velocidade = (int) (w * 0.01);
	}

	void CorrigeTamanhoCenario(double w, double h)
	{
		foreach(var a in hslayer1.Children)
		(a as Image ).WidthRequest = w;
		foreach(var a in hslayer2.Children)
		(a as Image ).WidthRequest = w;
		foreach(var a in hslayer3.Children)
		(a as Image ).WidthRequest = w;
		foreach( var a in hslayerChao.Children)
		(a as Image ).WidthRequest = w;

		hslayer1.WidthRequest=w*1.5;
		hslayer2.WidthRequest=w*1.5;
		hslayer3.WidthRequest=w*1.5;
		hslayerChao.WidthRequest=w*1.5;
	}

	void GerenciaCenarios()
	{
		MoveCenario();
		GerenciaCenario(hslayer1);
		GerenciaCenario(hslayer2);
		GerenciaCenario(hslayer3);
		GerenciaCenario(hslayerChao);
	}

	void MoveCenario()
	{
		hslayer1.TranslationX -= velocidade1;
		hslayer2.TranslationX -= velocidade2;
		hslayer3.TranslationX -= velocidade3;
		hslayerChao.TranslationX -= velocidade;
	}
	
	void GerenciaCenario(HorizontalStackLayout hsl)
	{
		var view = (hsl.Children.First() as Image);
		if(view.WidthRequest+hsl.TranslationX<0)
		{
			hsl.Children.Remove(view);
			hsl.Children.Add(view);
			hsl.TranslationX = view.TranslationX;
		}
	}
	void AplicaGravidade()
	{
		if (player.GetY()<0)
		player.MoveY(forcaGravidade);
		else if (player.GetY()>=0)
		{
			player.SetY(0);
			estaNoChao=true;
		}
	}
	void AplicaPulo()
	{
		estaNoChao=false;
		if(estaPulando && tempoPulando >=maxTempoPulando)
		{
			estaPulando=false;
			estaNoAr=true;
			tempoNoAr=0;
		}
		else if (estaNoAr && tempoNoAr >=maxTempoNoAr)
		{
			estaPulando=false;
			estaNoAr=false;
			tempoPulando=0;
			tempoNoAr=0;
		}
		else if (estaPulando && tempoPulando < maxTempoPulando)
		{
			player.MoveY (-ForcaPulo);
			tempoPulando ++;
		}
		else if (estaNoAr)
		tempoNoAr ++;
	}

	async Task Desenha()
	{
		while(!estaMorto)
			{
			if (!estaPulando && !estaNoAr)
			{
				AplicaGravidade();
				player.Desenha();
			}
			else 
				AplicaPulo();

			await Task.Delay(tempoEntreFrames);
		}
	}
}