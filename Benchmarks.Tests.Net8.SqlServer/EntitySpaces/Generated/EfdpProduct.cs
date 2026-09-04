
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2026.8.0020.0
EntitySpaces Driver  : SQL
Date Generated       : 30-08-2026 22:19:33
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Data;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace BusinessObjects
{
	/// <summary>
	/// Encapsulates the 'efdp_product' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(EfdpProduct))]	
	[XmlType("EfdpProduct")]
	public partial class EfdpProduct : esEfdpProduct
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new EfdpProduct();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Guid id)
		{
			var obj = new EfdpProduct();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Guid id, esSqlAccessType sqlAccessType)
		{
			var obj = new EfdpProduct();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("EfdpProductCollection")]
	public partial class EfdpProductCollection : esEfdpProductCollection, IEnumerable<EfdpProduct>
	{
		public EfdpProduct FindByPrimaryKey(System.Guid id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		
				
	}



	[Serializable]	
	public partial class EfdpProductQuery : esEfdpProductQuery
	{
		public EfdpProductQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		public EfdpProductQuery(string joinAlias, out EfdpProductQuery query)
		{
			query = this;
			this.es.JoinAlias = joinAlias;
		}

		override protected string GetQueryName()
		{
			return "EfdpProductQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(EfdpProductQuery query)
		{
			return EfdpProductQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator EfdpProductQuery(string query)
		{
			return (EfdpProductQuery)EfdpProductQuery.SerializeHelper.FromXml(query, typeof(EfdpProductQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esEfdpProduct : esEntity
	{
		public esEfdpProduct()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Guid id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Guid id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.Guid id)
		{
			EfdpProductQuery query = new EfdpProductQuery();
			query.Where(query.Id == id);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Guid id)
		{
			esParameters parms = new esParameters();
			parms.Add("Id", id);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to efdp_product.Id
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? Id
		{
			get
			{
				return base.GetSystemGuid(EfdpProductMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemGuid(EfdpProductMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(EfdpProductMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to efdp_product.name
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Name
		{
			get
			{
				return base.GetSystemString(EfdpProductMetadata.ColumnNames.Name);
			}
			
			set
			{
				if(base.SetSystemString(EfdpProductMetadata.ColumnNames.Name, value))
				{
					OnPropertyChanged(EfdpProductMetadata.PropertyNames.Name);
				}
			}
		}		
		
		/// <summary>
		/// Maps to efdp_product.description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(EfdpProductMetadata.ColumnNames.Description);
			}
			
			set
			{
				if(base.SetSystemString(EfdpProductMetadata.ColumnNames.Description, value))
				{
					OnPropertyChanged(EfdpProductMetadata.PropertyNames.Description);
				}
			}
		}		
		
		/// <summary>
		/// Maps to efdp_product.price
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? Price
		{
			get
			{
				return base.GetSystemDecimal(EfdpProductMetadata.ColumnNames.Price);
			}
			
			set
			{
				if(base.SetSystemDecimal(EfdpProductMetadata.ColumnNames.Price, value))
				{
					OnPropertyChanged(EfdpProductMetadata.PropertyNames.Price);
				}
			}
		}		
		
		/// <summary>
		/// Maps to efdp_product.old_price
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? OldPrice
		{
			get
			{
				return base.GetSystemDecimal(EfdpProductMetadata.ColumnNames.OldPrice);
			}
			
			set
			{
				if(base.SetSystemDecimal(EfdpProductMetadata.ColumnNames.OldPrice, value))
				{
					OnPropertyChanged(EfdpProductMetadata.PropertyNames.OldPrice);
				}
			}
		}		
		
		/// <summary>
		/// Maps to efdp_product.brand
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Brand
		{
			get
			{
				return base.GetSystemString(EfdpProductMetadata.ColumnNames.Brand);
			}
			
			set
			{
				if(base.SetSystemString(EfdpProductMetadata.ColumnNames.Brand, value))
				{
					OnPropertyChanged(EfdpProductMetadata.PropertyNames.Brand);
				}
			}
		}		
		
		/// <summary>
		/// Maps to efdp_product.customer_id
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? CustomerId
		{
			get
			{
				return base.GetSystemGuid(EfdpProductMetadata.ColumnNames.CustomerId);
			}
			
			set
			{
				if(base.SetSystemGuid(EfdpProductMetadata.ColumnNames.CustomerId, value))
				{
					this._UpToEfdpCustomerByCustomerId = null;
					this.OnPropertyChanged("UpToEfdpCustomerByCustomerId");
					OnPropertyChanged(EfdpProductMetadata.PropertyNames.CustomerId);
				}
			}
		}		
		
		/// <summary>
		/// Maps to efdp_product.product_page_id
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? ProductPageId
		{
			get
			{
				return base.GetSystemGuid(EfdpProductMetadata.ColumnNames.ProductPageId);
			}
			
			set
			{
				if(base.SetSystemGuid(EfdpProductMetadata.ColumnNames.ProductPageId, value))
				{
					this._UpToEfdpProductPageByProductPageId = null;
					this.OnPropertyChanged("UpToEfdpProductPageByProductPageId");
					OnPropertyChanged(EfdpProductMetadata.PropertyNames.ProductPageId);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected EfdpCustomer _UpToEfdpCustomerByCustomerId;
		[CLSCompliant(false)]
		internal protected EfdpProductPage _UpToEfdpProductPageByProductPageId;
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return EfdpProductMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public EfdpProductQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new EfdpProductQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(EfdpProductQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(EfdpProductQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private EfdpProductQuery query;		
	}



	[Serializable]
	abstract public partial class esEfdpProductCollection : esEntityCollection<EfdpProduct>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return EfdpProductMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "EfdpProductCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public EfdpProductQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new EfdpProductQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(EfdpProductQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new EfdpProductQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(EfdpProductQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((EfdpProductQuery)query);
		}

		#endregion
		
		private EfdpProductQuery query;
	}



	[Serializable]
	abstract public partial class esEfdpProductQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return EfdpProductMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Id": return this.Id;
				case "Name": return this.Name;
				case "Description": return this.Description;
				case "Price": return this.Price;
				case "OldPrice": return this.OldPrice;
				case "Brand": return this.Brand;
				case "CustomerId": return this.CustomerId;
				case "ProductPageId": return this.ProductPageId;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, EfdpProductMetadata.ColumnNames.Id, esSystemType.Guid); }
		} 
		
		public esQueryItem Name
		{
			get { return new esQueryItem(this, EfdpProductMetadata.ColumnNames.Name, esSystemType.String); }
		} 
		
		public esQueryItem Description
		{
			get { return new esQueryItem(this, EfdpProductMetadata.ColumnNames.Description, esSystemType.String); }
		} 
		
		public esQueryItem Price
		{
			get { return new esQueryItem(this, EfdpProductMetadata.ColumnNames.Price, esSystemType.Decimal); }
		} 
		
		public esQueryItem OldPrice
		{
			get { return new esQueryItem(this, EfdpProductMetadata.ColumnNames.OldPrice, esSystemType.Decimal); }
		} 
		
		public esQueryItem Brand
		{
			get { return new esQueryItem(this, EfdpProductMetadata.ColumnNames.Brand, esSystemType.String); }
		} 
		
		public esQueryItem CustomerId
		{
			get { return new esQueryItem(this, EfdpProductMetadata.ColumnNames.CustomerId, esSystemType.Guid); }
		} 
		
		public esQueryItem ProductPageId
		{
			get { return new esQueryItem(this, EfdpProductMetadata.ColumnNames.ProductPageId, esSystemType.Guid); }
		} 
		
		#endregion
		
	}


	
	public partial class EfdpProduct : esEfdpProduct
	{

				
				
		#region UpToEfdpCustomerByCustomerId - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_efdp_product_efdp_customer_customer_id
		/// </summary>
	    [EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeUpToEfdpCustomerByCustomerId()
		{
		    return this._UpToEfdpCustomerByCustomerId != null ? true : false;
		}
		

		[DataMember(Name="UpToEfdpCustomerByCustomerId", EmitDefaultValue = false)]
					
		public EfdpCustomer UpToEfdpCustomerByCustomerId
		{
			get
			{
                if (this._UpToEfdpCustomerByCustomerId == null)
                {
                    this._UpToEfdpCustomerByCustomerId = new EfdpCustomer();
                    this._UpToEfdpCustomerByCustomerId.es.Connection.Name = this.es.Connection.Name;
                    this.SetPreSave("UpToEfdpCustomerByCustomerId", this._UpToEfdpCustomerByCustomerId);

					if(this._UpToEfdpCustomerByCustomerId.Id == null && CustomerId != null)
                    {
                        if (!this.es.IsLazyLoadDisabled)
                        {
							this._UpToEfdpCustomerByCustomerId.Query.Where(this._UpToEfdpCustomerByCustomerId.Query.Id == this.CustomerId);
							this._UpToEfdpCustomerByCustomerId.Query.Load();
                        }
                    }
                }

				return this._UpToEfdpCustomerByCustomerId;
			}
			
			set
			{
				this.RemovePreSave("UpToEfdpCustomerByCustomerId");
				

				if(value == null)
				{
					this.CustomerId = null;
					this._UpToEfdpCustomerByCustomerId = null;
				}
				else
				{
					this.CustomerId = value.Id;
					this._UpToEfdpCustomerByCustomerId = value;
					this.SetPreSave("UpToEfdpCustomerByCustomerId", this._UpToEfdpCustomerByCustomerId);
				}
				
			}
		}
		#endregion
		

				
				
		#region UpToEfdpProductPageByProductPageId - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_efdp_product_efdp_product_page_product_page_id
		/// </summary>
	    [EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeUpToEfdpProductPageByProductPageId()
		{
		    return this._UpToEfdpProductPageByProductPageId != null ? true : false;
		}
		

		[DataMember(Name="UpToEfdpProductPageByProductPageId", EmitDefaultValue = false)]
					
		public EfdpProductPage UpToEfdpProductPageByProductPageId
		{
			get
			{
                if (this._UpToEfdpProductPageByProductPageId == null)
                {
                    this._UpToEfdpProductPageByProductPageId = new EfdpProductPage();
                    this._UpToEfdpProductPageByProductPageId.es.Connection.Name = this.es.Connection.Name;
                    this.SetPreSave("UpToEfdpProductPageByProductPageId", this._UpToEfdpProductPageByProductPageId);

					if(this._UpToEfdpProductPageByProductPageId.Id == null && ProductPageId != null)
                    {
                        if (!this.es.IsLazyLoadDisabled)
                        {
							this._UpToEfdpProductPageByProductPageId.Query.Where(this._UpToEfdpProductPageByProductPageId.Query.Id == this.ProductPageId);
							this._UpToEfdpProductPageByProductPageId.Query.Load();
                        }
                    }
                }

				return this._UpToEfdpProductPageByProductPageId;
			}
			
			set
			{
				this.RemovePreSave("UpToEfdpProductPageByProductPageId");
				

				if(value == null)
				{
					this.ProductPageId = null;
					this._UpToEfdpProductPageByProductPageId = null;
				}
				else
				{
					this.ProductPageId = value.Id;
					this._UpToEfdpProductPageByProductPageId = value;
					this.SetPreSave("UpToEfdpProductPageByProductPageId", this._UpToEfdpProductPageByProductPageId);
				}
				
			}
		}
		#endregion
		

		
		
	}
	



	[Serializable]
	public partial class EfdpProductMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected EfdpProductMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(EfdpProductMetadata.ColumnNames.Id, 0, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = EfdpProductMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(EfdpProductMetadata.ColumnNames.Name, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = EfdpProductMetadata.PropertyNames.Name;
			c.CharacterMaxLength = 150;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(EfdpProductMetadata.ColumnNames.Description, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = EfdpProductMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 1073741823;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(EfdpProductMetadata.ColumnNames.Price, 3, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = EfdpProductMetadata.PropertyNames.Price;
			c.NumericPrecision = 18;
			c.NumericScale = 2;
			m_columns.Add(c);
				
			c = new esColumnMetadata(EfdpProductMetadata.ColumnNames.OldPrice, 4, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = EfdpProductMetadata.PropertyNames.OldPrice;
			c.NumericPrecision = 18;
			c.NumericScale = 2;
			m_columns.Add(c);
				
			c = new esColumnMetadata(EfdpProductMetadata.ColumnNames.Brand, 5, typeof(System.String), esSystemType.String);
			c.PropertyName = EfdpProductMetadata.PropertyNames.Brand;
			c.CharacterMaxLength = 30;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(EfdpProductMetadata.ColumnNames.CustomerId, 6, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = EfdpProductMetadata.PropertyNames.CustomerId;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(EfdpProductMetadata.ColumnNames.ProductPageId, 7, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = EfdpProductMetadata.PropertyNames.ProductPageId;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public EfdpProductMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID
		{
			get { return base.m_dataID; }
		}	
		
		public bool MultiProviderMode
		{
			get { return false; }
		}		

		public esColumnMetadataCollection Columns
		{
			get	{ return base.m_columns; }
		}
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string Id = "Id";
			 public const string Name = "name";
			 public const string Description = "description";
			 public const string Price = "price";
			 public const string OldPrice = "old_price";
			 public const string Brand = "brand";
			 public const string CustomerId = "customer_id";
			 public const string ProductPageId = "product_page_id";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string Name = "Name";
			 public const string Description = "Description";
			 public const string Price = "Price";
			 public const string OldPrice = "OldPrice";
			 public const string Brand = "Brand";
			 public const string CustomerId = "CustomerId";
			 public const string ProductPageId = "ProductPageId";
		}
		#endregion	

		public esProviderSpecificMetadata GetProviderMetadata(string mapName)
		{
			MapToMeta mapMethod = mapDelegates[mapName];

			if (mapMethod != null)
				return mapMethod(mapName);
			else
				return null;
		}
		
		#region MAP esDefault
		
		static private int RegisterDelegateesDefault()
		{
			// This is only executed once per the life of the application
			lock (typeof(EfdpProductMetadata))
			{
				if(EfdpProductMetadata.mapDelegates == null)
				{
					EfdpProductMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (EfdpProductMetadata.meta == null)
				{
					EfdpProductMetadata.meta = new EfdpProductMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esDefault);
				mapDelegates.Add("esDefault", mapMethod);
				mapMethod("esDefault");
			}
			return 0;
		}			

		private esProviderSpecificMetadata esDefault(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();			


				meta.AddTypeMap("Id", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("Name", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Description", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Price", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("OldPrice", new esTypeMap("decimal", "System.Decimal"));
				meta.AddTypeMap("Brand", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("CustomerId", new esTypeMap("uniqueidentifier", "System.Guid"));
				meta.AddTypeMap("ProductPageId", new esTypeMap("uniqueidentifier", "System.Guid"));			
				
				
				
				meta.Source = "efdp_product";
				meta.Destination = "efdp_product";
				
				meta.spInsert = "proc_efdp_productInsert";				
				meta.spUpdate = "proc_efdp_productUpdate";		
				meta.spDelete = "proc_efdp_productDelete";
				meta.spLoadAll = "proc_efdp_productLoadAll";
				meta.spLoadByPrimaryKey = "proc_efdp_productLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private EfdpProductMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
