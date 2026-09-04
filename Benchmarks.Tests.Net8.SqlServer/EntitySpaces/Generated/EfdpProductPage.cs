
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
	/// Encapsulates the 'efdp_product_page' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(EfdpProductPage))]	
	[XmlType("EfdpProductPage")]
	public partial class EfdpProductPage : esEfdpProductPage
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new EfdpProductPage();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Guid id)
		{
			var obj = new EfdpProductPage();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Guid id, esSqlAccessType sqlAccessType)
		{
			var obj = new EfdpProductPage();
			obj.Id = id;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("EfdpProductPageCollection")]
	public partial class EfdpProductPageCollection : esEfdpProductPageCollection, IEnumerable<EfdpProductPage>
	{
		public EfdpProductPage FindByPrimaryKey(System.Guid id)
		{
			return this.SingleOrDefault(e => e.Id == id);
		}

		
				
	}



	[Serializable]	
	public partial class EfdpProductPageQuery : esEfdpProductPageQuery
	{
		public EfdpProductPageQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		public EfdpProductPageQuery(string joinAlias, out EfdpProductPageQuery query)
		{
			query = this;
			this.es.JoinAlias = joinAlias;
		}

		override protected string GetQueryName()
		{
			return "EfdpProductPageQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(EfdpProductPageQuery query)
		{
			return EfdpProductPageQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator EfdpProductPageQuery(string query)
		{
			return (EfdpProductPageQuery)EfdpProductPageQuery.SerializeHelper.FromXml(query, typeof(EfdpProductPageQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esEfdpProductPage : esEntity
	{
		public esEfdpProductPage()
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
			EfdpProductPageQuery query = new EfdpProductPageQuery();
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
		/// Maps to efdp_product_page.Id
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Guid? Id
		{
			get
			{
				return base.GetSystemGuid(EfdpProductPageMetadata.ColumnNames.Id);
			}
			
			set
			{
				if(base.SetSystemGuid(EfdpProductPageMetadata.ColumnNames.Id, value))
				{
					OnPropertyChanged(EfdpProductPageMetadata.PropertyNames.Id);
				}
			}
		}		
		
		/// <summary>
		/// Maps to efdp_product_page.title
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String Title
		{
			get
			{
				return base.GetSystemString(EfdpProductPageMetadata.ColumnNames.Title);
			}
			
			set
			{
				if(base.SetSystemString(EfdpProductPageMetadata.ColumnNames.Title, value))
				{
					OnPropertyChanged(EfdpProductPageMetadata.PropertyNames.Title);
				}
			}
		}		
		
		/// <summary>
		/// Maps to efdp_product_page.small_description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String SmallDescription
		{
			get
			{
				return base.GetSystemString(EfdpProductPageMetadata.ColumnNames.SmallDescription);
			}
			
			set
			{
				if(base.SetSystemString(EfdpProductPageMetadata.ColumnNames.SmallDescription, value))
				{
					OnPropertyChanged(EfdpProductPageMetadata.PropertyNames.SmallDescription);
				}
			}
		}		
		
		/// <summary>
		/// Maps to efdp_product_page.full_description
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String FullDescription
		{
			get
			{
				return base.GetSystemString(EfdpProductPageMetadata.ColumnNames.FullDescription);
			}
			
			set
			{
				if(base.SetSystemString(EfdpProductPageMetadata.ColumnNames.FullDescription, value))
				{
					OnPropertyChanged(EfdpProductPageMetadata.PropertyNames.FullDescription);
				}
			}
		}		
		
		/// <summary>
		/// Maps to efdp_product_page.image_link
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String ImageLink
		{
			get
			{
				return base.GetSystemString(EfdpProductPageMetadata.ColumnNames.ImageLink);
			}
			
			set
			{
				if(base.SetSystemString(EfdpProductPageMetadata.ColumnNames.ImageLink, value))
				{
					OnPropertyChanged(EfdpProductPageMetadata.PropertyNames.ImageLink);
				}
			}
		}		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return EfdpProductPageMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public EfdpProductPageQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new EfdpProductPageQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(EfdpProductPageQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(EfdpProductPageQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private EfdpProductPageQuery query;		
	}



	[Serializable]
	abstract public partial class esEfdpProductPageCollection : esEntityCollection<EfdpProductPage>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return EfdpProductPageMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "EfdpProductPageCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public EfdpProductPageQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new EfdpProductPageQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(EfdpProductPageQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new EfdpProductPageQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(EfdpProductPageQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((EfdpProductPageQuery)query);
		}

		#endregion
		
		private EfdpProductPageQuery query;
	}



	[Serializable]
	abstract public partial class esEfdpProductPageQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return EfdpProductPageMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "Id": return this.Id;
				case "Title": return this.Title;
				case "SmallDescription": return this.SmallDescription;
				case "FullDescription": return this.FullDescription;
				case "ImageLink": return this.ImageLink;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem Id
		{
			get { return new esQueryItem(this, EfdpProductPageMetadata.ColumnNames.Id, esSystemType.Guid); }
		} 
		
		public esQueryItem Title
		{
			get { return new esQueryItem(this, EfdpProductPageMetadata.ColumnNames.Title, esSystemType.String); }
		} 
		
		public esQueryItem SmallDescription
		{
			get { return new esQueryItem(this, EfdpProductPageMetadata.ColumnNames.SmallDescription, esSystemType.String); }
		} 
		
		public esQueryItem FullDescription
		{
			get { return new esQueryItem(this, EfdpProductPageMetadata.ColumnNames.FullDescription, esSystemType.String); }
		} 
		
		public esQueryItem ImageLink
		{
			get { return new esQueryItem(this, EfdpProductPageMetadata.ColumnNames.ImageLink, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class EfdpProductPage : esEfdpProductPage
	{

		#region EfdpProductCollectionByProductPageId - Zero To Many
		
		static public esPrefetchMap Prefetch_EfdpProductCollectionByProductPageId
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.EfdpProductPage.EfdpProductCollectionByProductPageId_Delegate;
				map.PropertyName = "EfdpProductCollectionByProductPageId";
				map.MyColumnName = "product_page_id";
				map.ParentColumnName = "Id";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void EfdpProductCollectionByProductPageId_Delegate(esPrefetchParameters data)
		{
			EfdpProductPageQuery parent = new EfdpProductPageQuery(data.NextAlias());

			EfdpProductQuery me = data.You != null ? data.You as EfdpProductQuery : new EfdpProductQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.Id == me.ProductPageId);

			data.You = parent;
		}	
	
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_efdp_product_efdp_product_page_product_page_id
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldSerializeEfdpProductCollectionByProductPageId()
		{
		    if(this._EfdpProductCollectionByProductPageId != null && this._EfdpProductCollectionByProductPageId.Count > 0)
				return true;
            else
				return false;
		}	
		

		[DataMember(Name="EfdpProductCollectionByProductPageId", EmitDefaultValue = false)]
		public EfdpProductCollection EfdpProductCollectionByProductPageId
		{
			get
			{
				if(this._EfdpProductCollectionByProductPageId == null)
				{
					this._EfdpProductCollectionByProductPageId = new EfdpProductCollection();
					this._EfdpProductCollectionByProductPageId.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("EfdpProductCollectionByProductPageId", this._EfdpProductCollectionByProductPageId);
				
					if (this.Id != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._EfdpProductCollectionByProductPageId.Query.Where(this._EfdpProductCollectionByProductPageId.Query.ProductPageId == this.Id);
							this._EfdpProductCollectionByProductPageId.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._EfdpProductCollectionByProductPageId.fks.Add(EfdpProductMetadata.ColumnNames.ProductPageId, this.Id);
					}
				}

				return this._EfdpProductCollectionByProductPageId;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._EfdpProductCollectionByProductPageId != null) 
				{ 
					this.RemovePostSave("EfdpProductCollectionByProductPageId"); 
					this._EfdpProductCollectionByProductPageId = null;
					
				} 
			} 			
		}
		

		
			
		
		private EfdpProductCollection _EfdpProductCollectionByProductPageId;
		#endregion

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "EfdpProductCollectionByProductPageId":
					coll = this.EfdpProductCollectionByProductPageId;
					break;	
			}

			return coll;
		}		
		/// <summary>
		/// Used internally by the entity's hierarchical properties.
		/// </summary>
		protected override List<esPropertyDescriptor> GetHierarchicalProperties()
		{
			List<esPropertyDescriptor> props = new List<esPropertyDescriptor>();
			
			props.Add(new esPropertyDescriptor(this, "EfdpProductCollectionByProductPageId", typeof(EfdpProductCollection), new EfdpProduct()));
		
			return props;
		}
		
	}
	



	[Serializable]
	public partial class EfdpProductPageMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected EfdpProductPageMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(EfdpProductPageMetadata.ColumnNames.Id, 0, typeof(System.Guid), esSystemType.Guid);
			c.PropertyName = EfdpProductPageMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(EfdpProductPageMetadata.ColumnNames.Title, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = EfdpProductPageMetadata.PropertyNames.Title;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(EfdpProductPageMetadata.ColumnNames.SmallDescription, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = EfdpProductPageMetadata.PropertyNames.SmallDescription;
			c.CharacterMaxLength = 120;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(EfdpProductPageMetadata.ColumnNames.FullDescription, 3, typeof(System.String), esSystemType.String);
			c.PropertyName = EfdpProductPageMetadata.PropertyNames.FullDescription;
			c.CharacterMaxLength = 500;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(EfdpProductPageMetadata.ColumnNames.ImageLink, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = EfdpProductPageMetadata.PropertyNames.ImageLink;
			c.CharacterMaxLength = 300;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public EfdpProductPageMetadata Meta()
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
			 public const string Title = "title";
			 public const string SmallDescription = "small_description";
			 public const string FullDescription = "full_description";
			 public const string ImageLink = "image_link";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string Title = "Title";
			 public const string SmallDescription = "SmallDescription";
			 public const string FullDescription = "FullDescription";
			 public const string ImageLink = "ImageLink";
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
			lock (typeof(EfdpProductPageMetadata))
			{
				if(EfdpProductPageMetadata.mapDelegates == null)
				{
					EfdpProductPageMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (EfdpProductPageMetadata.meta == null)
				{
					EfdpProductPageMetadata.meta = new EfdpProductPageMetadata();
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
				meta.AddTypeMap("Title", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("SmallDescription", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("FullDescription", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ImageLink", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "efdp_product_page";
				meta.Destination = "efdp_product_page";
				
				meta.spInsert = "proc_efdp_product_pageInsert";				
				meta.spUpdate = "proc_efdp_product_pageUpdate";		
				meta.spDelete = "proc_efdp_product_pageDelete";
				meta.spLoadAll = "proc_efdp_product_pageLoadAll";
				meta.spLoadByPrimaryKey = "proc_efdp_product_pageLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private EfdpProductPageMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
