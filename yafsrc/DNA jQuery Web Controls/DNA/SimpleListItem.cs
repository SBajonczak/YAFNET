﻿//  Copyright (c) 2009 Ray Liang (http://www.dotnetage.com)
///  Dual licensed under the MIT and GPL licenses:
///  http://www.opensource.org/licenses/mit-license.php
///  http://www.gnu.org/licenses/gpl.html

namespace DNA.UI
{
  #region Using

  using System;
  using System.ComponentModel;
  using System.Drawing.Design;
  using System.Security.Permissions;
  using System.Web;
  using System.Web.UI;
  using System.Web.UI.Design;
  using System.Web.UI.WebControls;

  #endregion

  /// <summary>
  /// The simple list item.
  /// </summary>
  [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
  [TypeConverter(typeof(ExpandableObjectConverter))]
  public class SimpleListItem : StateManagedObject
  {
    #region Properties

    /// <summary>
    ///   Gets/Sets the item's class name
    /// </summary>
    [Category("Appearance")]
    [PersistenceMode(PersistenceMode.Attribute)]
    [NotifyParentProperty(true)]
    [Description("Gets/Sets the item's class")]
    [CssClassProperty]
    [Bindable(true)]
    public virtual string CssClass
    {
      get
      {
        object obj = this.ViewState["CssClass"];
        return (obj == null) ? String.Empty : (string)obj;
      }

      set
      {
        this.ViewState["CssClass"] = value;
      }
    }

    /// <summary>
    ///   Gets/Sets the item's image icon url
    /// </summary>
    [Category("Appearance")]
    [PersistenceMode(PersistenceMode.Attribute)]
    [NotifyParentProperty(true)]
    [Description("Gets/Sets the item's image icon url")]
    [UrlProperty]
    [Bindable(true)]
    [Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
    public virtual string ImageUrl
    {
      get
      {
        object obj = this.ViewState["ImageUrl"];
        return (obj == null) ? String.Empty : (string)obj;
      }

      set
      {
        this.ViewState["ImageUrl"] = value;
      }
    }

    /// <summary>
    ///   Gets/Sets when set the item's naviage url
    /// </summary>
    [UrlProperty]
    [Bindable(true)]
    [Category("Behavior")]
    [NotifyParentProperty(true)]
    [PersistenceMode(PersistenceMode.Attribute)]
    [Description("Gets/Sets when set the item's naviage url")]
    [Editor(typeof(UrlEditor), typeof(UITypeEditor))]
    public virtual string NavigateUrl
    {
      get
      {
        object obj = this.ViewState["NavigateUrl"];
        return (obj == null) ? String.Empty : (string)obj;
      }

      set
      {
        this.ViewState["NavigateUrl"] = value;
      }
    }

    /// <summary>
    ///   Gets/Sets when click the item which the window open to.
    /// </summary>
    [Category("Behavior")]
    [PersistenceMode(PersistenceMode.Attribute)]
    [NotifyParentProperty(true)]
    [Description("Gets/Sets when click the item which the window open to")]
    [Bindable(true)]
    [TypeConverter(typeof(TargetConverter))]
    public virtual string Target
    {
      get
      {
        object obj = this.ViewState["Target"];
        return (obj == null) ? String.Empty : (string)obj;
      }

      set
      {
        this.ViewState["Target"] = value;
      }
    }

    /// <summary>
    ///   Gets/Sets the item's text
    /// </summary>
    [Category("Appearance")]
    [PersistenceMode(PersistenceMode.Attribute)]
    [NotifyParentProperty(true)]
    [Description("Gets/Sets the item's text")]
    [Localizable(true)]
    [Bindable(true)]
    public virtual string Text
    {
      get
      {
        object obj = this.ViewState["Text"];
        return (obj == null) ? String.Empty : (string)obj;
      }

      set
      {
        this.ViewState["Text"] = value;
      }
    }

    #endregion
  }
}