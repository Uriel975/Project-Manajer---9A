namespace Project_Manager.Services.BO
{
    public class TblAsignacionBO
{
	string estadoasignacion;
	int fkproblemas;
	int idasignacion;
	TblEmpleadoBO otblEmpleadoBO;

	public string EstadoAsignacion
	{
		get { return estadoasignacion; }
		set { estadoasignacion = value; }
	}
	public int FKProblemas
	{
		get { return fkproblemas; }
		set { fkproblemas = value; }
	}
	public int IDAsignacion
	{
		get { return idasignacion; }
		set { idasignacion = value; }
	}
	public TblEmpleadoBO OTblEmpleadoBO
	{
		get { return otblEmpleadoBO; }
		set { otblEmpleadoBO = value; }
	}
	}
}
