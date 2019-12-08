using System;

namespace PrismLib.ViewModels
{
    /// <summary>
    /// メニューリストアイテムクラス
    /// </summary>
    public class MenuListItem
    {
        /// <summary>
        /// メニューID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// タイトル
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 説明
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 登録日
        /// </summary>
        public DateTime RegistrationDate { get; set; }
        /// <summary>
        /// NEWフラグ
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">メニューID</param>
        /// <param name="title">タイトル</param>
        /// <param name="description">説明</param>
        /// <param name="registrationDate">登録日</param>
        /// <param name="isNew">NEWフラグ</param>
        public MenuListItem(int id, string title, string description, DateTime registrationDate, bool isNew = false)
        {
            Id = id;
            Title = title;
            Description = description;
            RegistrationDate = registrationDate;
            IsNew = isNew;
        }
    }
}
