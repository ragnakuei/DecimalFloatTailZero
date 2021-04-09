
using System;
using System.ComponentModel.DataAnnotations;

namespace CreateDb
{
/// <summary>
/// 訂單主表
/// </summary>
public class Order
{
	/// <summary>
	/// ID
	/// </summary>
	[Display(Name = "ID", Prompt = "ID")]
	[Required(ErrorMessage = "請填寫{0}")]
	public long Id { get; set; }

	/// <summary>
	/// Guid
	/// </summary>
	[Display(Name = "Guid", Prompt = "Guid")]
	[Required(ErrorMessage = "請填寫{0}")]
	public Guid Guid { get; set; }

	/// <summary>
	/// 小計
	/// </summary>
	[Display(Name = "小計", Prompt = "小計")]
	[Required(ErrorMessage = "請填寫{0}")]
	[StringLength(30, ErrorMessage = "{0} 長度要介於 {2} 及 {1} 之間")]
	public string SubTotal { get; set; }

	/// <summary>
	/// 營業稅
	/// </summary>
	[Display(Name = "營業稅", Prompt = "營業稅")]
	[Required(ErrorMessage = "請填寫{0}")]
	[StringLength(30, ErrorMessage = "{0} 長度要介於 {2} 及 {1} 之間")]
	public string BusinessTax { get; set; }

	/// <summary>
	/// 總計
	/// </summary>
	[Display(Name = "總計", Prompt = "總計")]
	[Required(ErrorMessage = "請填寫{0}")]
	[StringLength(30, ErrorMessage = "{0} 長度要介於 {2} 及 {1} 之間")]
	public string Total { get; set; }


}

/// <summary>
/// 訂單明細表
/// </summary>
public class OrderDetail
{
	/// <summary>
	/// ID
	/// </summary>
	[Display(Name = "ID", Prompt = "ID")]
	[Required(ErrorMessage = "請填寫{0}")]
	public long Id { get; set; }

	/// <summary>
	/// Guid
	/// </summary>
	[Display(Name = "Guid", Prompt = "Guid")]
	[Required(ErrorMessage = "請填寫{0}")]
	public Guid Guid { get; set; }

	/// <summary>
	/// 訂單 Guid
	/// </summary>
	[Display(Name = "訂單 Guid", Prompt = "訂單 Guid")]
	[Required(ErrorMessage = "請填寫{0}")]
	public Guid OrderGuid { get; set; }

	/// <summary>
	/// 單價
	/// </summary>
	[Display(Name = "單價", Prompt = "單價")]
	[Required(ErrorMessage = "請填寫{0}")]
	[StringLength(30, ErrorMessage = "{0} 長度要介於 {2} 及 {1} 之間")]
	public string UnitPrice { get; set; }

	/// <summary>
	/// 數量
	/// </summary>
	[Display(Name = "數量", Prompt = "數量")]
	[Required(ErrorMessage = "請填寫{0}")]
	public int Count { get; set; }

	/// <summary>
	/// 備註
	/// </summary>
	[Display(Name = "備註", Prompt = "備註")]
	[StringLength(1000, ErrorMessage = "{0} 長度要介於 {2} 及 {1} 之間")]
	public string Comment { get; set; }


	/// <summary>
	/// 訂單
	/// </summary>
	public Order Order { get; set; }

}

}
