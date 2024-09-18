// See https://aka.ms/new-console-template for more information
using Dio.Series.Class;
using Dio.Series.Enums;
using Dio.Series.Repository;


SeriesRepository _seriesRepository = new SeriesRepository();


Console.WriteLine("Starting Hello, World!");

string optionUser = GetOptions();

while (optionUser.ToUpper() != "X")
{
    switch (optionUser.ToUpper())
    {
        case "1":
            await ListAll();
            break;
        case "2":
            await Insert();
            break;
        case "3":
            await Update();
            break;
        case "4":
            await Delete();
            break;
        case "5":
            await GetById();
            break;
        case "C":
            Console.Clear();
            break;
        default:
            throw new ArgumentNullException(nameof(optionUser));
    }

    optionUser = GetOptions();
}

async Task ListAll()
{
    Console.WriteLine("List all Series...");
    var list = await _seriesRepository.GetAllAsync();

    if (list.Count == 0)
    {
        Console.WriteLine("Nenhuma Série Cadastrada");
        return;
    }

    foreach (var serie in list)
    {
        Console.WriteLine($"Id: {serie.ReturnId()} - {serie.ReturnTitle()} - {(serie.Inactive() ? "Sim" : "Não")}");
        serie.ToString();
    }
}

static string GetOptions()
{
    Console.WriteLine();
    Console.WriteLine("DIO Séries a seu dispor");
    Console.WriteLine("Informe a opção desejada:");
    Console.WriteLine("1 - Listar Todas");
    Console.WriteLine("2 - Inserir Nova");
    Console.WriteLine("3 - Atualizar");
    Console.WriteLine("4 - Excluir");
    Console.WriteLine("5 - Visualizar Série");
    Console.WriteLine("C - Limpar tela.");
    Console.WriteLine("X - Sair.");
    return Console.ReadLine();
}

async Task Insert()
{
     Console.WriteLine("Inserir Nova Série");
    foreach (int i in Enum.GetValues(typeof(EGender)))
    {
        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(EGender), i));
    }

    Console.WriteLine("Digite o gênero entre as opções acima.");
    int genderId = int.Parse(Console.ReadLine());

     Console.WriteLine("Digite o Título da Série: ");
    string title = Console.ReadLine();

     Console.WriteLine("Digite a Descrição da Série: ");
    string description = Console.ReadLine();

    Console.WriteLine("Digite o ano da série.");
    int year = int.Parse(Console.ReadLine());

    var id = await _seriesRepository.NextIdAsync();
    var newSerie = new Serie(id, description, title, year, (EGender)genderId);
    await _seriesRepository.InsertAsync(newSerie);
}

async Task Update()
{
    Console.WriteLine("Digite o id da série: ");
    int id = int.Parse(Console.ReadLine());

     Console.WriteLine("Inserir Nova Série");
    foreach (int i in Enum.GetValues(typeof(EGender)))
    {
        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(EGender), i));
    }

    Console.WriteLine("Digite o gênero entre as opções acima.");
    int genderId = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o Título da Série: ");
    string title = Console.ReadLine();

    Console.WriteLine("Digite a Descrição da Série: ");
    string description = Console.ReadLine();

    Console.WriteLine("Digite o ano da série.");
    int year = int.Parse(Console.ReadLine());

    var newSerie = new Serie(id, description, title, year, (EGender)genderId);
    await _seriesRepository.UpdateAsync(id, newSerie);
}

async Task Delete()
{
     Console.WriteLine("Digite o id da série: ");
    int indiceSerie = int.Parse(Console.ReadLine());
    await _seriesRepository.DeleteAsync(indiceSerie);
}

async Task GetById()
{
    Console.WriteLine("Digite o id da série: ");
    int indiceSerie = int.Parse(Console.ReadLine());
    var serie = await _seriesRepository.GetAsync(indiceSerie);
    Console.WriteLine(serie.ToString());
}
