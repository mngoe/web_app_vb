'------------------------------------------------------------------------------
' <généré automatiquement>
'     Ce code a été généré par un outil.
'
'     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
'     le code est régénéré.
' </généré automatiquement>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class FindMedicalService

    '''<summary>
    '''Contrôle hfServId.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents hfServId As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Contrôle hfServCode.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents hfServCode As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Contrôle Label8.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents Label8 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle pnlTop.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents pnlTop As Global.System.Web.UI.WebControls.Panel

    '''<summary>
    '''Contrôle L_SERVICECODE.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents L_SERVICECODE As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle txtServiceCode.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtServiceCode As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contrôle L_SERVICENAME.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents L_SERVICENAME As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle txtServiceName.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents txtServiceName As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Contrôle L_SERVICETYPE.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents L_SERVICETYPE As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle ddlType.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents ddlType As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Contrôle chkLegacy.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents chkLegacy As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''Contrôle B_SEARCH.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents B_SEARCH As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Contrôle L_FOUNDUSERS.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents L_FOUNDUSERS As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle pnlGrid.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents pnlGrid As Global.System.Web.UI.WebControls.Panel

    '''<summary>
    '''Contrôle gvService.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents gvService As Global.System.Web.UI.WebControls.GridView

    '''<summary>
    '''Contrôle pnlButtons.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents pnlButtons As Global.System.Web.UI.WebControls.Panel

    '''<summary>
    '''Contrôle B_ADD.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents B_ADD As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Contrôle B_EDIT.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents B_EDIT As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Contrôle B_DELETE.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents B_DELETE As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Contrôle B_CANCEL.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents B_CANCEL As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Contrôle lblMsg.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents lblMsg As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Contrôle validationSummary.
    '''</summary>
    '''<remarks>
    '''Champ généré automatiquement.
    '''Pour modifier, déplacez la déclaration de champ du fichier de concepteur dans le fichier code-behind.
    '''</remarks>
    Protected WithEvents validationSummary As Global.System.Web.UI.WebControls.ValidationSummary
End Class
