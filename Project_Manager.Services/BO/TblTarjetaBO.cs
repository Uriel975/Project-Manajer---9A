namespace Project_Manager.Services.BO
{
    public class TblTarjetaBO
{
	string numerotarjeta;
	string cvvtarjeta;
	string fechatarjeta;
	int idtarjeta;
	TblEmpleadoBO otblEmpleadoBO;

	public string NumeroTarjeta
	{
		get { return numerotarjeta; }
		set { numerotarjeta = value; }
	}
	public string CVVTarjeta
	{
		get { return cvvtarjeta; }
		set { cvvtarjeta = value; }
	}
	public string FechaTarjeta
	{
		get { return fechatarjeta; }
		set { fechatarjeta = value; }
	}
	public int IDTarjeta
	{
		get { return idtarjeta; }
		set { idtarjeta = value; }
	}
	public TblEmpleadoBO OTblEmpleadoBO
	{
		get { return otblEmpleadoBO; }
		set { otblEmpleadoBO = value; }
	}
	}
}
