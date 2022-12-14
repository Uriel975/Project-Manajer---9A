using System;

namespace Project_Manager.Services.BO
{
    public class TblDocumentacionBO
{
	string titulodocumentacion;
	string descripciondocumentacion;
	DateTime estimaciondocumentacion;
	DateTime fechadocumentacion;
	int fkasignacion;
	int iddocumentacion;
	TblEmpleadoBO otblEmpleadoBO;

	public string TituloDocumentacion
	{
		get { return titulodocumentacion; }
		set { titulodocumentacion = value; }
	}
	public string DescripcionDocumentacion
	{
		get { return descripciondocumentacion; }
		set { descripciondocumentacion = value; }
	}
	public DateTime EstimacionDocumentacion
	{
		get { return estimaciondocumentacion; }
		set { estimaciondocumentacion = value; }
	}
	public DateTime FechaDocumentacion
	{
		get { return fechadocumentacion; }
		set { fechadocumentacion = value; }
	}
	public int FKAsignacion
	{
		get { return fkasignacion; }
		set { fkasignacion = value; }
	}
	public int IDDocumentacion
	{
		get { return iddocumentacion; }
		set { iddocumentacion = value; }
	}
	public TblEmpleadoBO OTblEmpleadoBO
	{
		get { return otblEmpleadoBO; }
		set { otblEmpleadoBO = value; }
	}
	}
}
