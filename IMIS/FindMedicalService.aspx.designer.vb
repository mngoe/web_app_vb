'------------------------------------------------------------------------------
' <g�n�r� automatiquement>
'     Ce code a �t� g�n�r� par un outil.
'
'     Les modifications apport�es � ce fichier peuvent provoquer un comportement incorrect et seront perdues si
'     le code est r�g�n�r�.
' </g�n�r� automatiquement>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class FindMedicalService

    '''<summary>
    '''Contr�le hfServId.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents hfServId As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Contr�le hfServCode.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents hfServCode As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Contr�le Label8.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label8 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le pnlTop.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents pnlTop As Global.System.Web.UI.WebControls.Panel

    '''<summary>
    '''Contr�le L_SERVICECODE.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents L_SERVICECODE As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le txtServiceCode.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtServiceCode As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le L_SERVICENAME.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents L_SERVICENAME As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le txtServiceName.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtServiceName As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contr�le L_SERVICETYPE.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents L_SERVICETYPE As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le ddlType.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents ddlType As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Contr�le chkLegacy.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents chkLegacy As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''Contr�le B_SEARCH.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents B_SEARCH As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Contr�le L_FOUNDUSERS.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents L_FOUNDUSERS As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le pnlGrid.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents pnlGrid As Global.System.Web.UI.WebControls.Panel

    '''<summary>
    '''Contr�le gvService.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents gvService As Global.System.Web.UI.WebControls.GridView

    '''<summary>
    '''Contr�le pnlButtons.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents pnlButtons As Global.System.Web.UI.WebControls.Panel

    '''<summary>
    '''Contr�le B_ADD.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents B_ADD As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Contr�le B_EDIT.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents B_EDIT As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Contr�le B_DELETE.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents B_DELETE As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Contr�le B_CANCEL.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents B_CANCEL As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Contr�le lblMsg.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents lblMsg As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contr�le validationSummary.
    '''</summary>
    '''<remarks>
    '''Champ g�n�r� automatiquement.
    '''Pour modifier, d�placez la d�claration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents validationSummary As Global.System.Web.UI.WebControls.ValidationSummary
End Class
