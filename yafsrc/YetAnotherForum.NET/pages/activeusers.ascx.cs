/* Yet Another Forum.NET
 * Copyright (C) 2006-2007 Jaben Cargman
 * http://www.yetanotherforum.net/
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 */
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using YAF.Classes.Utils;
using YAF.Classes.Data;

namespace YAF.Pages // YAF.Pages
{
	/// <summary>
	/// Summary description for activeusers.
	/// </summary>
	public partial class activeusers : YAF.Classes.Base.ForumPage
	{

		public activeusers()
			: base( "ACTIVEUSERS" )
		{
		}

		protected void Page_Load( object sender, System.EventArgs e )
		{
			// checks for administrator setting whether to allow active users list viewing
			// it's denied for all users (administrators are always allowed to view it)
			if (PageContext.BoardSettings.ActiveUsersViewPermissions == (int)ViewPermissions.Nobody
				&& !PageContext.IsAdmin)
			{
				YafBuildLink.AccessDenied();
			}
			// only registered users are allowed to see active users list
			else if (PageContext.BoardSettings.ActiveUsersViewPermissions == (int)ViewPermissions.RegisteredUsers
				&& PageContext.IsGuest)
			{
				YAF.Classes.Utils.YafBuildLink.Redirect(YAF.Classes.Utils.ForumPages.login, "ReturnUrl={0}", General.GetSafeRawUrl());
			}

			if (!IsPostBack)
			{
				PageLinks.AddLink( PageContext.BoardSettings.Name, YAF.Classes.Utils.YafBuildLink.GetLink( YAF.Classes.Utils.ForumPages.forum ) );
				PageLinks.AddLink( GetText( "TITLE" ), "" );

				UserList.DataSource = YAF.Classes.Data.DB.active_list( PageContext.PageBoardID, true );
				DataBind();
			}
		}
	}
}
