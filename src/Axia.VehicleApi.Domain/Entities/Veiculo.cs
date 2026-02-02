using Axia.VehicleApi.Domain.Enums;

namespace Axia.VehicleApi.Domain.Entities;

public class Veiculo
{
    private Veiculo() { }

    public Veiculo(Guid id, string descricao, Marca marca, string modelo, string? opcionais, decimal? valor)
    {
        Id = id;
        Descricao = descricao;
        Marca = marca;
        Modelo = modelo;
        Opcionais = opcionais;
        Valor = valor;
    }

    public Guid Id { get; private set; }
    public string Descricao { get; private set; } = string.Empty;
    public Marca Marca { get; private set; }
    public string Modelo { get; private set; } = string.Empty;

    public string? Opcionais { get; private set; }
    public decimal? Valor { get; private set; }

    public void Atualizar(string descricao, Marca marca, string modelo, string? opcionais, decimal? valor)
    {
        Descricao = descricao;
        Marca = marca;
        Modelo = modelo;
        Opcionais = opcionais;
        Valor = valor;
    }
}
