using System;

namespace Project_Manager.Services.BO
{
    public class TblProblemaBO
{
	string tituloproblema;
	string descripcionproblema;
	DateTime fechaproblema;
	int fkproyecto;
	int idproblema;
	TblClienteBO otblClienteBO;

	public string TituloProblema
	{
		get { return tituloproblema; }
		set { tituloproblema = value; }
	}
	public string DescripcionProblema
	{
		get { return descripcionproblema; }
		set { descripcionproblema = value; }
	}
	public DateTime FechaProblema
	{
		get { return fechaproblema; }
		set { fechaproblema = value; }
	}
	public int FKProyecto
	{
		get { return fkproyecto; }
		set { fkproyecto = value; }
	}
	public int IDProblema
	{
		get { return idproblema; }
		set { idproblema = value; }
	}
	public TblClienteBO OTblClienteBO
	{
		get { return otblClienteBO; }
		set { otblClienteBO = value; }
	}
	}
}
