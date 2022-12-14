#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamenSoftware
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="PruebaEmpleados")]
	public partial class PruebaDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void Insertareas(areas instance);
    partial void Updateareas(areas instance);
    partial void Deleteareas(areas instance);
    partial void Insertempleados(empleados instance);
    partial void Updateempleados(empleados instance);
    partial void Deleteempleados(empleados instance);
    #endregion
		
		public PruebaDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["PruebaEmpleadosConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PruebaDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PruebaDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PruebaDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PruebaDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<areas> areas
		{
			get
			{
				return this.GetTable<areas>();
			}
		}
		
		public System.Data.Linq.Table<empleados> empleados
		{
			get
			{
				return this.GetTable<empleados>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.areas")]
	public partial class areas : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_area;
		
		private string _nombre;
		
		private EntitySet<empleados> _empleados;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_areaChanging(int value);
    partial void Onid_areaChanged();
    partial void OnnombreChanging(string value);
    partial void OnnombreChanged();
    #endregion
		
		public areas()
		{
			this._empleados = new EntitySet<empleados>(new Action<empleados>(this.attach_empleados), new Action<empleados>(this.detach_empleados));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_area", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_area
		{
			get
			{
				return this._id_area;
			}
			set
			{
				if ((this._id_area != value))
				{
					this.Onid_areaChanging(value);
					this.SendPropertyChanging();
					this._id_area = value;
					this.SendPropertyChanged("id_area");
					this.Onid_areaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre", DbType="VarChar(40) NOT NULL", CanBeNull=false)]
		public string nombre
		{
			get
			{
				return this._nombre;
			}
			set
			{
				if ((this._nombre != value))
				{
					this.OnnombreChanging(value);
					this.SendPropertyChanging();
					this._nombre = value;
					this.SendPropertyChanged("nombre");
					this.OnnombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="areas_empleados", Storage="_empleados", ThisKey="id_area", OtherKey="id_area")]
		public EntitySet<empleados> empleados
		{
			get
			{
				return this._empleados;
			}
			set
			{
				this._empleados.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_empleados(empleados entity)
		{
			this.SendPropertyChanging();
			entity.areas = this;
		}
		
		private void detach_empleados(empleados entity)
		{
			this.SendPropertyChanging();
			entity.areas = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.empleados")]
	public partial class empleados : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_empleado;
		
		private string _nombre;
		
		private string _apellidoPaterno;
		
		private string _correo;
		
		private int _id_area;
		
		private EntityRef<areas> _areas;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_empleadoChanging(int value);
    partial void Onid_empleadoChanged();
    partial void OnnombreChanging(string value);
    partial void OnnombreChanged();
    partial void OnapellidoPaternoChanging(string value);
    partial void OnapellidoPaternoChanged();
    partial void OncorreoChanging(string value);
    partial void OncorreoChanged();
    partial void Onid_areaChanging(int value);
    partial void Onid_areaChanged();
    #endregion
		
		public empleados()
		{
			this._areas = default(EntityRef<areas>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_empleado", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_empleado
		{
			get
			{
				return this._id_empleado;
			}
			set
			{
				if ((this._id_empleado != value))
				{
					this.Onid_empleadoChanging(value);
					this.SendPropertyChanging();
					this._id_empleado = value;
					this.SendPropertyChanged("id_empleado");
					this.Onid_empleadoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre", DbType="VarChar(40) NOT NULL", CanBeNull=false)]
		public string nombre
		{
			get
			{
				return this._nombre;
			}
			set
			{
				if ((this._nombre != value))
				{
					this.OnnombreChanging(value);
					this.SendPropertyChanging();
					this._nombre = value;
					this.SendPropertyChanged("nombre");
					this.OnnombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_apellidoPaterno", DbType="VarChar(40) NOT NULL", CanBeNull=false)]
		public string apellidoPaterno
		{
			get
			{
				return this._apellidoPaterno;
			}
			set
			{
				if ((this._apellidoPaterno != value))
				{
					this.OnapellidoPaternoChanging(value);
					this.SendPropertyChanging();
					this._apellidoPaterno = value;
					this.SendPropertyChanged("apellidoPaterno");
					this.OnapellidoPaternoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_correo", DbType="VarChar(40) NOT NULL", CanBeNull=false)]
		public string correo
		{
			get
			{
				return this._correo;
			}
			set
			{
				if ((this._correo != value))
				{
					this.OncorreoChanging(value);
					this.SendPropertyChanging();
					this._correo = value;
					this.SendPropertyChanged("correo");
					this.OncorreoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_area", DbType="Int NOT NULL")]
		public int id_area
		{
			get
			{
				return this._id_area;
			}
			set
			{
				if ((this._id_area != value))
				{
					if (this._areas.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_areaChanging(value);
					this.SendPropertyChanging();
					this._id_area = value;
					this.SendPropertyChanged("id_area");
					this.Onid_areaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="areas_empleados", Storage="_areas", ThisKey="id_area", OtherKey="id_area", IsForeignKey=true)]
		public areas areas
		{
			get
			{
				return this._areas.Entity;
			}
			set
			{
				areas previousValue = this._areas.Entity;
				if (((previousValue != value) 
							|| (this._areas.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._areas.Entity = null;
						previousValue.empleados.Remove(this);
					}
					this._areas.Entity = value;
					if ((value != null))
					{
						value.empleados.Add(this);
						this._id_area = value.id_area;
					}
					else
					{
						this._id_area = default(int);
					}
					this.SendPropertyChanged("areas");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
