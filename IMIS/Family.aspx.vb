''Copyright (c) 2016-2017 Swiss Agency for Development and Cooperation (SDC)
''
''The program users must agree to the following terms:
''
''Copyright notices
''This program is free software: you can redistribute it and/or modify it under the terms of the GNU AGPL v3 License as published by the 
''Free Software Foundation, version 3 of the License.
''This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of 
''MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU AGPL v3 License for more details www.gnu.org.
''
''Disclaimer of Warranty
''There is no warranty for the program, to the extent permitted by applicable law; except when otherwise stated in writing the copyright 
''holders and/or other parties provide the program "as is" without warranty of any kind, either expressed or implied, including, but not 
''limited to, the implied warranties of merchantability and fitness for a particular purpose. The entire risk as to the quality and 
''performance of the program is with you. Should the program prove defective, you assume the cost of all necessary servicing, repair or correction.
''
''Limitation of Liability 
''In no event unless required by applicable law or agreed to in writing will any copyright holder, or any other party who modifies and/or 
''conveys the program as permitted above, be liable to you for damages, including any general, special, incidental or consequential damages 
''arising out of the use or inability to use the program (including but not limited to loss of data or data being rendered inaccurate or losses 
''sustained by you or third parties or a failure of the program to operate with any other programs), even if such holder or other party has been 
''advised of the possibility of such damages.
''
''In case of dispute arising out or in relation to the use of the program, it is subject to the public law of Switzerland. The place of jurisdiction is Berne.
'
' 
'

Public Class Family
    Inherits System.Web.UI.Page
    Private Family As New IMIS_BI.FamilyBI
    Private eFamily As New IMIS_EN.tblFamilies
    Private eInsuree As New IMIS_EN.tblInsuree
    Private dtImage As New DataTable
    Private imisgen As New IMIS_Gen
    Private userBI As New IMIS_BI.UserBI
    Dim FamilyUUID As Guid

    Private Sub FormatForm()
        Dim Adjustibility As String = ""
        'Beneficiary card
        Adjustibility = General.getControlSetting("BeneficiaryCard")
        trBeneficiary.Visible = Not (Adjustibility = "N")
        trBeneficiary1.Visible = Not (Adjustibility = "N")
        rfBeneficiary.Enabled = (Adjustibility = "M")

        'Confirmation
        Adjustibility = General.getControlSetting("Confirmation")
        trConfirmation.Visible = Not (Adjustibility = "N")
        rfConfirmation.Enabled = (Adjustibility = "M")

        Adjustibility = General.getControlSetting("ConfirmationNo")
        L_CONFIRMATIONNO.Visible = Not (Adjustibility = "N")
        txtConfirmationNo.Visible = Not (Adjustibility = "N")
        rfConfirmationNo.Enabled = (Adjustibility = "M")

        'CurrentAddress
        Adjustibility = General.getControlSetting("CurrentAddress")
        trCurrentAddress.Visible = Not (Adjustibility = "N")
        rfCurrentAddress.Enabled = (Adjustibility = "M")

        'Current District
        Adjustibility = General.getControlSetting("CurrentDistrict")
        trCurrentDistrict.Visible = Not (Adjustibility = "N")
        trCurrentRegion.Visible = Not (Adjustibility = "N")
        rfCurrentDistrict.Enabled = (Adjustibility = "M")
        rfCurrentRegion.Enabled = (Adjustibility = "M")

        'Current Municipality
        Adjustibility = General.getControlSetting("CurrentMunicipality")
        trCurrentMunicipality.Visible = Not (Adjustibility = "N")
        rfCurrentVDC.Enabled = (Adjustibility = "M")

        'Current Village
        Adjustibility = General.getControlSetting("CurrentVillage")
        trCurrentVillage.Visible = Not (Adjustibility = "N")
        rfCurrentVillage.Enabled = (Adjustibility = "M")

        'Education
        Adjustibility = General.getControlSetting("Education")
        trEducation.Visible = Not (Adjustibility = "N")
        rfEducation.Enabled = (Adjustibility = "M")

        'FamilyType
        Adjustibility = General.getControlSetting("FamilyType")
        trType.Visible = Not (Adjustibility = "N")
        rfType.Enabled = (Adjustibility = "M")


        'FSP District
        Adjustibility = General.getControlSetting("FSPDistrict")
        trFSPDistrict.Visible = Not (Adjustibility = "N")
        trFSPRegion.Visible = Not (Adjustibility = "N")
        rfDistrictFSP.Enabled = (Adjustibility = "M")
        rfRegionFSP.Enabled = (Adjustibility = "M")

        'FSP Category
        Adjustibility = General.getControlSetting("FSPCategory")
        trFSPCategory.Visible = Not (Adjustibility = "N")
        rfFSPCategory.Enabled = (Adjustibility = "M")

        'FSP
        Adjustibility = General.getControlSetting("FSP")
        trFSP.Visible = Not (Adjustibility = "N")
        rfFSP.Enabled = (Adjustibility = "M")

        'Identification Type
        Adjustibility = General.getControlSetting("IdentificationType")
        'trIdentificationType.Visible = Not (Adjustibility = "N")
        rfIdType.Enabled = (Adjustibility = "M")

        'Identification Number
        Adjustibility = General.getControlSetting("IdentificationNumber")
        'trIdentificationNo.Visible = Not (Adjustibility = "N")
        rfIdNo1.Enabled = (Adjustibility = "M")

        'Email
        Adjustibility = General.getControlSetting("InsureeEmail")
        trEmail.Visible = Not (Adjustibility = "N")
        rfEmail.Enabled = (Adjustibility = "M")

        'Marital Status
        Adjustibility = General.getControlSetting("MaritalStatus")
        trMaritalStatus.Visible = Not (Adjustibility = "N")
        rfMaritalStatus.Enabled = (Adjustibility = "M")

        'Permanent Address
        Adjustibility = General.getControlSetting("PermanentAddress")
        L_ADDRESS.Visible = Not (Adjustibility = "N")
        txtAddress.Visible = Not (Adjustibility = "N")
        rfAddress.Enabled = (Adjustibility = "M")

        'Poverty
        Adjustibility = General.getControlSetting("Poverty")
        trPoverty.Visible = Not (Adjustibility = "N")
        rfPoverty.Enabled = (Adjustibility = "M")

        'Profession
        Adjustibility = General.getControlSetting("Profession")
        'trProfession.Visible = Not (Adjustibility = "N")
        'rfProfession.Enabled = (Adjustibility = "M")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = True Then Return

        FormatForm()

        If HttpContext.Current.Request.QueryString("f") IsNot Nothing Then
            eFamily.FamilyUUID = Guid.Parse(HttpContext.Current.Request.QueryString("f"))
            eFamily.FamilyID = Family.GetFamilyIdByUUID(eFamily.FamilyUUID)
        End If

        RunPageSecurity()
        Try
            Dim dtRegions As DataTable = Family.GetRegions(imisgen.getUserId(Session("User")), True)
            ddlRegion.DataSource = dtRegions
            ddlRegion.DataValueField = "RegionId"
            ddlRegion.DataTextField = "RegionName"
            ddlRegion.DataBind()
            If dtRegions.Rows.Count = 1 Then
                FillDistricts()
            End If
            ddlGender.DataSource = Family.GetGender
            ddlGender.DataValueField = "Code"
            ddlGender.DataTextField = "Gender"
            ddlGender.DataBind()

            ddlPoverty.DataSource = Family.GetYesNO
            ddlPoverty.DataValueField = "Code"
            ddlPoverty.DataTextField = "Status"
            ddlPoverty.DataBind()

            ddlMarital.DataSource = Family.GetMaritalStatus
            ddlMarital.DataValueField = "Code"
            ddlMarital.DataTextField = "Status"
            ddlMarital.DataBind()

            ddlConfirmationType.DataSource = Family.GetSubsidy
            ddlConfirmationType.DataValueField = "ConfirmationTypeCode"
            ddlConfirmationType.DataTextField = If(Request.Cookies("CultureInfo").Value = "en", "ConfirmationType", "AltLanguage")
            ddlConfirmationType.DataBind()

            ddlCardIssued.DataSource = Family.GetYesNO
            ddlCardIssued.DataValueField = "Code"
            ddlCardIssued.DataTextField = "Status"
            ddlCardIssued.DataBind()

            ddlType.DataSource = Family.GetTypes
            ddlType.DataValueField = "FamilyTypeCode"
            ddlType.DataTextField = If(Request.Cookies("CultureInfo").Value = "en", "FamilyType", "AltLanguage") '"FamilyType"
            ddlType.DataBind()

            ddlProfession.DataSource = Family.GetProfession
            ddlProfession.DataValueField = "ProfessionId"
            ddlProfession.DataTextField = If(Request.Cookies("CultureInfo").Value = "en", "Profession", "AltLanguage")
            ddlProfession.DataBind()

            ddlEducation.DataSource = Family.GetEducation
            ddlEducation.DataValueField = "EducationId"
            ddlEducation.DataTextField = If(Request.Cookies("CultureInfo").Value = "en", "Education", "AltLanguage")
            ddlEducation.DataBind()

            ddlEthnicity.DataSource = Family.GetEthnicity
            ddlEthnicity.DataValueField = "Code"
            ddlEthnicity.DataTextField = "Ethnicity"
            ddlEthnicity.DataBind()

            ddlIdType.DataSource = Family.GetTypeOfIdentity
            ddlIdType.DataValueField = "IdentificationCode"
            ddlIdType.DataTextField = If(Request.Cookies("CultureInfo").Value = "en", "IdentificationTypes", "AltLanguage") ' 
            ddlIdType.DataBind()


            Dim dtFSPRegion As DataTable = Family.GetRegionsAll(imisgen.getUserId(Session("User")))
            ddlFSPRegion.DataSource = dtFSPRegion
            ddlFSPRegion.DataValueField = "RegionId"
            ddlFSPRegion.DataTextField = "RegionName"
            ddlFSPRegion.DataBind()

            If dtFSPRegion.Rows.Count = 1 Then
                FillFSPDistricts()
            End If

            ddlFSPCateogory.DataSource = Family.GetHFLevel
            ddlFSPCateogory.DataValueField = "Code"
            ddlFSPCateogory.DataTextField = "HFLevel"
            ddlFSPCateogory.DataBind()

            FillHF()

            'Get Current District, Wards and Villages

            Dim dtCurrentRegion As DataTable = Family.GetRegionsAll(imisgen.getUserId(Session("User")), True)
            ddlCurrentRegion.DataSource = dtCurrentRegion
            ddlCurrentRegion.DataValueField = "RegionId"
            ddlCurrentRegion.DataTextField = "RegionName"
            ddlCurrentRegion.DataBind()


            If dtCurrentRegion.Rows.Count = 1 Then
                FillCurrentDistricts()
            End If
            ddlNetWorkProvider1.DataSource = Family.GetNetworkProvider
            ddlNetWorkProvider1.DataValueField = "Code"
            ddlNetWorkProvider1.DataTextField = "Status"
            ddlNetWorkProvider1.DataBind()

            ddlNetWorkProvider2.DataSource = Family.GetNetworkProvider
            ddlNetWorkProvider2.DataValueField = "Code"
            ddlNetWorkProvider2.DataTextField = "Status"
            ddlNetWorkProvider2.DataBind()

            ddlPreferredPaiementMode.DataSource = Family.GetPreferredPaiementMode
            ddlPreferredPaiementMode.DataValueField = "Code"
            ddlPreferredPaiementMode.DataTextField = "Status"
            ddlPreferredPaiementMode.DataBind()

            ddlHeadStatus.DataSource = Family.GetStatusProvider
            ddlHeadStatus.DataValueField = "Code"
            ddlHeadStatus.DataTextField = "Status"
            ddlHeadStatus.DataBind()

            ddlLengthPresentLocation.DataSource = Family.GetLengthStayProvider
            ddlLengthPresentLocation.DataValueField = "Code"
            ddlLengthPresentLocation.DataTextField = "Status"
            ddlLengthPresentLocation.DataBind()

            ddlHHHealthStatus.DataSource = Family.GetHHealthStatusProvider
            ddlHHHealthStatus.DataValueField = "Code"
            ddlHHHealthStatus.DataTextField = "Status"
            ddlHHHealthStatus.DataBind()

            ddlHHNutritionalStatus.DataSource = Family.GetNutritionalStatusProvider
            ddlHHNutritionalStatus.DataValueField = "Code"
            ddlHHNutritionalStatus.DataTextField = "Status"
            ddlHHNutritionalStatus.DataBind()

            ddlHHMentalPhysicalDisability.DataSource = Family.GetYesNO
            ddlHHMentalPhysicalDisability.DataValueField = "Code"
            ddlHHMentalPhysicalDisability.DataTextField = "Status"
            ddlHHMentalPhysicalDisability.DataBind()

            ddlRelationship.DataSource = Family.GetRelations
            ddlRelationship.DataValueField = "RelationId"
            ddlRelationship.DataTextField = If(Request.Cookies("CultureInfo").Value = "en", "Relation", "AltLanguage")
            ddlRelationship.DataBind()

            ddlChildGender.DataSource = Family.GetGender
            ddlChildGender.DataValueField = "Code"
            ddlChildGender.DataTextField = "Gender"
            ddlChildGender.DataBind()

            ddlCHBirthCertificate.DataSource = Family.GetYesNO
            ddlCHBirthCertificate.DataValueField = "Code"
            ddlCHBirthCertificate.DataTextField = "Status"
            ddlCHBirthCertificate.DataBind()

            ddlCHEnrolmentStatus.DataSource = Family.GetYesNO
            ddlCHEnrolmentStatus.DataValueField = "Code"
            ddlCHEnrolmentStatus.DataTextField = "Status"
            ddlCHEnrolmentStatus.DataBind()

            ddlCHEnrolmentWhichClass.DataSource = Family.GetCHEnrolmentWhichClassProvider
            ddlCHEnrolmentWhichClass.DataValueField = "Code"
            ddlCHEnrolmentWhichClass.DataTextField = "Status"
            ddlCHEnrolmentWhichClass.DataBind()

            ddlCHEnrolmentScore.DataSource = Family.GetChildCurrentSchoolPerfProvider
            ddlCHEnrolmentScore.DataValueField = "Code"
            ddlCHEnrolmentScore.DataTextField = "Status"
            ddlCHEnrolmentScore.DataBind()

            ddlCHEnrolmentOutofSchool.DataSource = Family.GetCHEnrolmentOutofSchool
            ddlCHEnrolmentOutofSchool.DataValueField = "Code"
            ddlCHEnrolmentOutofSchool.DataTextField = "Status"
            ddlCHEnrolmentOutofSchool.DataBind()

            ddlCHParentalStatus.DataSource = Family.GetCHParentalStatus
            ddlCHParentalStatus.DataValueField = "Code"
            ddlCHParentalStatus.DataTextField = "Status"
            ddlCHParentalStatus.DataBind()


            If Not eFamily.FamilyID = 0 Then
                Family.LoadFamily(eFamily)
                ddlRegion.SelectedValue = eFamily.RegionId
                ddlDistrict.SelectedValue = eFamily.DistrictId
                ddlVillage.SelectedValue = eFamily.LocationId
                ddlWard.SelectedValue = eFamily.WardId
                'ddlDistrict.SelectedValue = eFamily.tblDistricts.DistrictID
                ddlPoverty.SelectedValue = eFamily.Poverty
                ddlConfirmationType.SelectedValue = eFamily.ConfirmationType
                ddlEthnicity.SelectedValue = eFamily.Ethnicity
                ddlCardIssued.SelectedValue = eFamily.tblInsuree.CardIssued
                ddlGender.SelectedValue = eFamily.tblInsuree.Gender
                ddlMarital.SelectedValue = eFamily.tblInsuree.Marital
                'Nouveaux champs ajoutés dans programme
                ddlNetWorkProvider1.SelectedValue = eFamily.tblInsuree.NetWorkProvider1
                ddlNetWorkProvider2.SelectedValue = eFamily.tblInsuree.NetWorkProvider2
                ddlPreferredPaiementMode.SelectedValue = eFamily.tblInsuree.PreferredPaiementMode
                ddlHeadStatus.SelectedValue = eFamily.tblInsuree.HeadStatus
                ddlLengthPresentLocation.SelectedValue = eFamily.tblInsuree.LengthPresentLocation
                If eFamily.tblInsuree.DOB_unknow Then
                    chkDateInconnue.Checked = eFamily.tblInsuree.DOB_unknow
                Else
                    chkDateInconnue.Checked = False
                End If
                If eFamily.tblInsuree.IsHeadPhone1 Then
                    chkIsHeadPhone1.Checked = eFamily.tblInsuree.IsHeadPhone1
                Else
                    chkIsHeadPhone1.Checked = False
                End If
                If eFamily.tblInsuree.IsHeadPhone2 Then
                    chkIsHeadPhone2.Checked = eFamily.tblInsuree.IsHeadPhone2
                Else
                    chkIsHeadPhone2.Checked = False
                End If
                txtMaleLivingHoushold.Text = eFamily.tblInsuree.MaleLivingHoushold
                txtFemaleLivingHoushold.Text = eFamily.tblInsuree.FemaleLivingHoushold
                txtPersonLivingHoushold.Text = eFamily.tblInsuree.PersonLivingHoushold
                txtHHNBChildrenLivingM.Text = eFamily.tblInsuree.HHNBChildrenLivingM
                txtHHNBChildrenLivingF.Text = eFamily.tblInsuree.HHNBChildrenLivingF
                txtHHNBChildrenLivingT.Text = eFamily.tblInsuree.HHNBChildrenLivingT
                txtHHNBChildrenSchoolLivingM.Text = eFamily.tblInsuree.HHNBChildrenSchoolLivingM
                txtHHNBChildrenSchoolLivingF.Text = eFamily.tblInsuree.HHNBChildrenSchoolLivingF
                txtHHNBChildrenSchoolLivingT.Text = eFamily.tblInsuree.HHNBChildrenSchoolLivingT
                txtHHNBChildrenCompleteSchoolLivingM.Text = eFamily.tblInsuree.HHNBChildrenCompleteSchoolLivingM
                txtHHNBChildrenCompleteSchoolLivingF.Text = eFamily.tblInsuree.HHNBChildrenCompleteSchoolLivingF
                txtHHNBChildrenCompleteSchoolLivingT.Text = eFamily.tblInsuree.HHNBChildrenCompleteSchoolLivingT
                txtHHNBChildrenDropSchoolLivingM.Text = eFamily.tblInsuree.HHNBChildrenDropSchoolLivingM
                txtHHNBChildrenDropSchoolLivingF.Text = eFamily.tblInsuree.HHNBChildrenDropSchoolLivingF
                txtHHNBChildrenDropSchoolLivingT.Text = eFamily.tblInsuree.HHNBChildrenDropSchoolLivingT
                txtHHNBGirlsMarried.Text = eFamily.tblInsuree.HHNBGirlsMarried
                txtHHNBChildrenBirthCertifM.Text = eFamily.tblInsuree.HHNBChildrenBirthCertifM
                txtHHNBChildrenBirthCertifF.Text = eFamily.tblInsuree.HHNBChildrenBirthCertifF
                txtHHNBChildrenBirthCertifT.Text = eFamily.tblInsuree.HHNBChildrenBirthCertifT
                ddlHHHealthStatus.SelectedValue = eFamily.tblInsuree.HHHealthStatus
                txtHHExpenditure.Text = eFamily.tblInsuree.HHExpenditure
                txtHHExpenditurePerH.Text = eFamily.tblInsuree.HHExpenditurePerH
                ddlHHNutritionalStatus.SelectedValue = eFamily.tblInsuree.HHNutritionalStatus
                ddlHHMentalPhysicalDisability.SelectedValue = eFamily.tblInsuree.HHMentalPhysicalDisability
                txtHHMentalPhysicalDisabilityM.Text = eFamily.tblInsuree.HHMentalPhysicalDisabilityM
                txtHHMentalPhysicalDisabilityF.Text = eFamily.tblInsuree.HHMentalPhysicalDisabilityF
                txtHHMentalPhysicalDisabilityT.Text = eFamily.tblInsuree.HHMentalPhysicalDisabilityT
                If eFamily.tblInsuree.HHMentalPhysicalDisabilityO1 Then
                    chkHHMentalPhysicalDisabilityO1.Checked = eFamily.tblInsuree.HHMentalPhysicalDisabilityO1
                Else
                    chkHHMentalPhysicalDisabilityO1.Checked = False
                End If
                If eFamily.tblInsuree.HHMentalPhysicalDisabilityO2 Then
                    chkHHMentalPhysicalDisabilityO2.Checked = eFamily.tblInsuree.HHMentalPhysicalDisabilityO2
                Else
                    chkHHMentalPhysicalDisabilityO2.Checked = False
                End If
                If eFamily.tblInsuree.HHMentalPhysicalDisabilityO3 Then
                    chkHHMentalPhysicalDisabilityO3.Checked = eFamily.tblInsuree.HHMentalPhysicalDisabilityO3
                Else
                    chkHHMentalPhysicalDisabilityO3.Checked = False
                End If
                txtHHMentalPhysicalDisabilityO4.Text = eFamily.tblInsuree.HHMentalPhysicalDisabilityO4


                ddlRelationship.SelectedValue = eFamily.tblInsuree.Relationship
                ddlChildGender.SelectedValue = eFamily.tblInsuree.ChildGender
                txtBirthDateChild.Text = eFamily.tblInsuree.BirthDateChild
                If eFamily.tblInsuree.DateInconnueChild Then
                    chkDateInconnueChild.Checked = eFamily.tblInsuree.DateInconnueChild
                Else
                    chkDateInconnueChild.Checked = False
                End If
                ddlCHBirthCertificate.SelectedValue = eFamily.tblInsuree.CHBirthCertificate
                ddlCHEnrolmentStatus.SelectedValue = eFamily.tblInsuree.CHEnrolmentStatus
                txtChildSchoolName.Text = eFamily.tblInsuree.ChildSchoolName
                ddlCHEnrolmentWhichClass.SelectedValue = eFamily.tblInsuree.CHEnrolmentWhichClass
                ddlCHEnrolmentScore.SelectedValue = eFamily.tblInsuree.CHEnrolmentScore
                ddlCHEnrolmentOutofSchool.SelectedValue = eFamily.tblInsuree.CHEnrolmentOutofSchool
                ddlCHParentalStatus.SelectedValue = eFamily.tblInsuree.CHParentalStatus
                If eFamily.tblInsuree.ResidentialStatus1 Then
                    chkResidentialStatus1.Checked = eFamily.tblInsuree.ResidentialStatus1
                Else
                    chkResidentialStatus1.Checked = False
                End If
                If eFamily.tblInsuree.ResidentialStatus2 Then
                    chkResidentialStatus2.Checked = eFamily.tblInsuree.ResidentialStatus2
                Else
                    chkResidentialStatus2.Checked = False
                End If
                If eFamily.tblInsuree.ResidentialStatus3 Then
                    chkResidentialStatus3.Checked = eFamily.tblInsuree.ResidentialStatus3
                Else
                    chkResidentialStatus3.Checked = False
                End If
                If eFamily.tblInsuree.ResidentialStatus4 Then
                    chkResidentialStatus4.Checked = eFamily.tblInsuree.ResidentialStatus4
                Else
                    chkResidentialStatus4.Checked = False
                End If
                If eFamily.tblInsuree.ResidentialStatus5 Then
                    chkResidentialStatus5.Checked = eFamily.tblInsuree.ResidentialStatus5
                Else
                    chkResidentialStatus5.Checked = False
                End If
                If eFamily.tblInsuree.ResidentialStatus6 Then
                    chkResidentialStatus6.Checked = eFamily.tblInsuree.ResidentialStatus6
                Else
                    chkResidentialStatus6.Checked = False
                End If
                If eFamily.tblInsuree.ResidentialStatus7 Then
                    chkResidentialStatus7.Checked = eFamily.tblInsuree.ResidentialStatus7
                Else
                    chkResidentialStatus7.Checked = False
                End If

                If eFamily.tblInsuree.CHSpecialNeeds1 Then
                    chkCHSpecialNeeds1.Checked = eFamily.tblInsuree.CHSpecialNeeds1
                Else
                    chkCHSpecialNeeds1.Checked = False
                End If
                If eFamily.tblInsuree.CHSpecialNeeds2 Then
                    chkCHSpecialNeeds2.Checked = eFamily.tblInsuree.CHSpecialNeeds2
                Else
                    chkCHSpecialNeeds2.Checked = False
                End If
                If eFamily.tblInsuree.CHSpecialNeeds3 Then
                    chkCHSpecialNeeds3.Checked = eFamily.tblInsuree.CHSpecialNeeds3
                Else
                    chkCHSpecialNeeds3.Checked = False
                End If
                If eFamily.tblInsuree.CHSpecialNeeds4 Then
                    chkCHSpecialNeeds4.Checked = eFamily.tblInsuree.CHSpecialNeeds4
                Else
                    chkCHSpecialNeeds4.Checked = False
                End If
                If eFamily.tblInsuree.CHSpecialNeeds5 Then
                    chkCHSpecialNeeds5.Checked = eFamily.tblInsuree.CHSpecialNeeds5
                Else
                    chkCHSpecialNeeds5.Checked = False
                End If
                txtCHSpecialNeeds6.Text = eFamily.tblInsuree.CHSpecialNeeds6
                txtChildName.Text = eFamily.tblInsuree.ChildName
                


                'txtMaleLivingHoushold.Text = eFamily.tblInsuree.MaleLivingHoushold

                'Fin nouveaux champs

                If eFamily.tblInsuree.Profession IsNot Nothing Then ddlProfession.SelectedValue = eFamily.tblInsuree.Profession
                If eFamily.tblInsuree.Education IsNot Nothing Then ddlEducation.SelectedValue = eFamily.tblInsuree.Education
                txtCHFID.Text = eFamily.tblInsuree.CHFID.Trim
                txtBirthDate.Text = eFamily.tblInsuree.DOB
                txtLastName.Text = eFamily.tblInsuree.LastName
                txtOtherNames.Text = eFamily.tblInsuree.OtherNames
                txtPassport.Text = eFamily.tblInsuree.passport
                txtPhone.Text = eFamily.tblInsuree.Phone
                txtAltPhone.Text = eFamily.tblInsuree.AltPhone
                ddlType.SelectedValue = eFamily.FamilyType
                txtAddress.Text = eFamily.FamilyAddress
                txtConfirmationNo.Text = eFamily.ConfirmationNo

                hfFamilyIsOffline.Value = If(eFamily.isOffline Is Nothing, False, eFamily.isOffline)
                hfInsureeIsOffline.Value = If(eFamily.tblInsuree.isOffline Is Nothing, False, eFamily.tblInsuree.isOffline)


                'Addition for Nepal >> Start

                ddlIdType.SelectedValue = eFamily.tblInsuree.TypeOfId

                ddlFSPDistrict.SelectedValue = eFamily.tblInsuree.FSPDistrict
                ddlFSPCateogory.SelectedValue = eFamily.tblInsuree.FSPCategory
                FillHF()
                ddlFSP.SelectedValue = eFamily.tblInsuree.tblHF.HfID

                txtCurrentAddress.Text = eFamily.tblInsuree.CurrentAddress

                ddlCurrentRegion.SelectedValue = eInsuree.CurrentRegion
                FillCurrentDistricts()
                ddlCurDistrict.SelectedValue = eInsuree.CurDistrict
                GetCurVillages()

                ddlCurVDC.SelectedValue = eInsuree.CurWard
                getCurWards()

                ddlCurWard.SelectedValue = eInsuree.CurrentVillage

                'Addition for Nepal >> End

                If eFamily.ValidityTo.HasValue Or ((IMIS_Gen.offlineHF Or IMIS_Gen.OfflineCHF) And Not If(eFamily.isOffline Is Nothing, False, eFamily.isOffline)) Then
                    pnlImages.Enabled = False
                    B_SAVE.Visible = False
                    btnBrowse.Enabled = False
                    'Panel1.Enabled = False
                End If
            End If
            FillImageDL()
            Session("ParentUrl") = "FindFamily.aspx"
        Catch ex As Exception
            Session("Msg") = imisgen.getMessage("M_ERRORMESSAGE")
            imisgen.Log(Page.Title & " : " & imisgen.getLoginName(Session("User")), ex)
            'EventLog.WriteEntry("IMIS", Page.Title & " : " & imisgen.getLoginName(Session("User")) & " : " & ex.Message, EventLogEntryType.Error, 999)
        End Try
    End Sub


    Private Sub FillFSPDistricts()
        ddlFSPDistrict.DataSource = Family.GetDistrictsAll(imisgen.getUserId(Session("User")), ddlFSPRegion.SelectedValue, True)
        ddlFSPDistrict.DataValueField = "DistrictId"
        ddlFSPDistrict.DataTextField = "DistrictName"
        ddlFSPDistrict.DataBind()
    End Sub
    Private Sub FillDistricts()
        Dim dtDistricts As DataTable = Family.GetDistricts(imisgen.getUserId(Session("User")), True, ddlRegion.SelectedValue)
        ddlDistrict.DataSource = dtDistricts
        ddlDistrict.DataValueField = "DistrictId"
        ddlDistrict.DataTextField = "DistrictName"
        ddlDistrict.DataBind()
        If dtDistricts.Rows.Count = 1 Then
            GetWards()
        End If
    End Sub
    Private Sub RunPageSecurity()
        Dim UserID As Integer = imisgen.getUserId(Session("User"))
        If userBI.RunPageSecurity(IMIS_EN.Enums.Pages.Family, Page) Then
            B_SAVE.Visible = userBI.checkRights(IMIS_EN.Enums.Rights.FamilyAdd, UserID)
            If Not B_SAVE.Visible Then
                pnlBody.Enabled = False
                pnlImages.Enabled = False
                'Panel1.Enabled = False
            End If
        Else
            Dim RefUrl = Request.Headers("Referer")
            Server.Transfer("Redirect.aspx?perm=0&page=" & IMIS_EN.Enums.Pages.Family.ToString & "&retUrl=" & RefUrl)
        End If
    End Sub
    Private Sub ddlDistricts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDistrict.SelectedIndexChanged
        Try
            GetWards()
        Catch ex As Exception
            imisgen.Alert(imisgen.getMessage("M_ERRORMESSAGE"), pnlBody, alertPopupTitle:="IMIS")
            imisgen.Log(Page.Title & " : " & imisgen.getLoginName(Session("User")), ex)
            'EventLog.WriteEntry("IMIS", Page.Title & " : " & imisgen.getLoginName(Session("User")) & " : " & ex.Message, EventLogEntryType.Error, 999)
        End Try
    End Sub
    Private Sub GetWards()
        Dim dtWards As DataTable = Family.GetWards(ddlDistrict.SelectedValue, True)
        Dim wards As Integer = dtWards.Rows.Count
        If wards > 0 Then
            ddlWard.DataSource = dtWards
            ddlWard.DataValueField = "WardId"
            ddlWard.DataTextField = "WardName"
            ddlWard.DataBind()
        Else
            ddlWard.Items.Clear()
        End If
        getVillages(wards)
    End Sub
    Private Sub getCurWards(Optional ByVal Wards As Integer = 1)
        If ddlCurVDC.SelectedIndex < 0 Then Exit Sub
        If Wards > 0 And Not ddlCurVDC.SelectedValue = 0 Then
            ddlCurWard.DataSource = Family.GetCurVillages(ddlCurVDC.SelectedValue)
            ddlCurWard.DataValueField = "VillageId"
            ddlCurWard.DataTextField = "VillageName"
            ddlCurWard.DataBind()
        Else
            ddlCurWard.Items.Clear()
        End If

    End Sub
    Private Sub getVillages(Optional ByVal Wards As Integer = 1)
        If ddlWard.SelectedIndex < 0 Then Exit Sub
        If Wards > 0 And Not ddlWard.SelectedValue = 0 Then
            ddlVillage.DataSource = Family.GetVillages(ddlWard.SelectedValue, True)
            ddlVillage.DataValueField = "VillageId"
            ddlVillage.DataTextField = "VillageName"
            ddlVillage.DataBind()
        Else
            ddlVillage.Items.Clear()
        End If

    End Sub
    Private Sub GetCurVillages()
        Dim dtVillages As DataTable = Family.GetCurWards(ddlCurDistrict.SelectedValue)
        Dim Villages As Integer = dtVillages.Rows.Count
        If Villages > 0 Then
            ddlCurVDC.DataSource = dtVillages
            ddlCurVDC.DataValueField = "WardId"
            ddlCurVDC.DataTextField = "WardName"
            ddlCurVDC.DataBind()
        Else
            ddlCurVDC.Items.Clear()
        End If
        getCurWards(Villages)
    End Sub
    Private Sub gvWards_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlWard.SelectedIndexChanged
        getVillages()

    End Sub
    Private Sub FillImageDL()
        Dim dt As New DataTable
        Dim Insuree As New IMIS_BI.InsureeBI
        dt = Insuree.FetchNewImages(Server.MapPath(IMIS_EN.AppConfiguration.SubmittedFolder), eInsuree.CHFID)
        dlImages.DataSource = dt
        dlImages.DataBind()
    End Sub
    Private Sub FetchNewImage()
        If Len(Trim(eInsuree.CHFID)) > 0 Then
            Dim Insuree As New IMIS_BI.InsureeBI
            dtImage = Insuree.FetchNewImages(Server.MapPath(IMIS_EN.AppConfiguration.SubmittedFolder), eInsuree.CHFID)
            If dtImage.Rows.Count > 0 Then
                Image1.ImageUrl = IMIS_EN.AppConfiguration.SubmittedFolder & dtImage.Rows(0)("ImagePath")

            Else
                Image1.ImageUrl = ""
                Dim ltl As New Literal()
                ltl.Text = "<script language='javascript'>document.getElementByID</script>"
                pnlBody.Controls.Add(ltl)
                'Response.Write()
            End If

        Else
            Image1.ImageUrl = ""

        End If
    End Sub
    Private Sub FillHF()
        'If ddlFSPDistrict.SelectedValue = 0 Or ddlFSPCateogory.SelectedValue = "" Then Exit Sub

        ddlFSP.DataSource = Family.GetFSPHF(Val(ddlFSPDistrict.SelectedValue), ddlFSPCateogory.SelectedValue)
        ddlFSP.DataValueField = "HFID"
        ddlFSP.DataTextField = "HFCode"
        ddlFSP.DataBind()

    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles B_SAVE.Click
        Try
            'Dim birthdate As Date
            'If Not IsDate(Date.ParseExact(txtBirthDate.Text, "dd/MM/yyyy", Nothing)) Then
            '    Return
            'Else
            '    birthdate = Date.ParseExact(txtBirthDate.Text, "dd/MM/yyyy", Nothing)
            'End If

            If Not Family.CheckCHFID(txtCHFID.Text) = True Then
                imisgen.Alert(txtCHFID.Text & imisgen.getMessage("M_NOTVALIDCHFNUMBER"), pnlButtons, alertPopupTitle:="IMIS")
                Return
            End If


            Dim ePhotos As New IMIS_EN.tblPhotos

            Dim msg As String = ""
            'If Trim(txtCHFID.Text).Length < 9 Then
            '    msg = imisgen.getMessage("M_CHFNUMBERFEWCHARACTERS")

            'Else
            If Family.FamilyExists(txtCHFID.Text) Then
                msg = imisgen.getMessage("M_CHFNUMBERMEMBEREXISTS")

            End If

            If msg.Length > 0 Then
                Dim ltl As New Literal()
                ltl.Text = "<script language='javascript'>$(document).ready(function(){popup.alert('" & msg & "');});</script>"
                pnlBody.Controls.Add(ltl)
                'Response.Write(")
                Exit Sub
            End If

            Dim dt As New DataTable
            dt = DirectCast(Session("User"), DataTable)

            'eFamily.DistrictID = ddlDistrict.SelectedValue
            If ddlVillage.SelectedValue.Length > 0 Then eFamily.LocationId = ddlVillage.SelectedValue

            'eFamily.WardID = ddlWard.SelectedValue
            If ddlPoverty.SelectedValue.Length > 0 Then eFamily.Poverty = ddlPoverty.SelectedValue
            If ddlConfirmationType.SelectedValue.Length > 0 Then eFamily.ConfirmationType = ddlConfirmationType.SelectedValue
            If ddlEthnicity.SelectedValue.Length > 0 Then eFamily.Ethnicity = ddlEthnicity.SelectedValue
            eInsuree.CHFID = txtCHFID.Text.Trim
            eInsuree.LastName = txtLastName.Text
            eInsuree.OtherNames = txtOtherNames.Text
            '''Traitement des nouveaux champs pour l'ajout
            If txtBirthDate.Text.Length > 0 Then
                eInsuree.DOB = Date.ParseExact(txtBirthDate.Text, "dd/MM/yyyy", Nothing)
            Else
                eInsuree.DOB = Date.ParseExact("01/01/1900", "dd/MM/yyyy", Nothing)
            End If
            If chkDateInconnue.Checked Then
                eInsuree.DOB_unknow = True
            Else
                eInsuree.DOB_unknow = False
            End If
            If chkIsHeadPhone1.Checked Then
                eInsuree.IsHeadPhone1 = True
            Else
                eInsuree.IsHeadPhone1 = False
            End If
            If chkIsHeadPhone2.Checked Then
                eInsuree.IsHeadPhone2 = True
            Else
                eInsuree.IsHeadPhone2 = False
            End If
            If ddlNetWorkProvider1.SelectedValue <> "" Then eInsuree.NetWorkProvider1 = ddlNetWorkProvider1.SelectedValue
            If ddlNetWorkProvider2.SelectedValue <> "" Then eInsuree.NetWorkProvider2 = ddlNetWorkProvider2.SelectedValue
            If ddlPreferredPaiementMode.SelectedValue <> "" Then eInsuree.PreferredPaiementMode = ddlPreferredPaiementMode.SelectedValue
            eInsuree.MaleLivingHoushold = txtMaleLivingHoushold.Text
            eInsuree.FemaleLivingHoushold = txtFemaleLivingHoushold.Text
            eInsuree.PersonLivingHoushold = txtPersonLivingHoushold.Text
            eInsuree.HHNBChildrenLivingM = txtHHNBChildrenLivingM.Text
            eInsuree.HHNBChildrenLivingF = txtHHNBChildrenLivingF.Text
            eInsuree.HHNBChildrenLivingT = txtHHNBChildrenLivingT.Text
            eInsuree.HHNBChildrenSchoolLivingM = txtHHNBChildrenSchoolLivingM.Text
            eInsuree.HHNBChildrenSchoolLivingF = txtHHNBChildrenSchoolLivingF.Text
            eInsuree.HHNBChildrenSchoolLivingT = txtHHNBChildrenSchoolLivingT.Text
            eInsuree.HHNBChildrenCompleteSchoolLivingM = txtHHNBChildrenCompleteSchoolLivingM.Text
            eInsuree.HHNBChildrenCompleteSchoolLivingF = txtHHNBChildrenCompleteSchoolLivingF.Text
            eInsuree.HHNBChildrenCompleteSchoolLivingT = txtHHNBChildrenCompleteSchoolLivingT.Text
            eInsuree.HHNBChildrenDropSchoolLivingM = txtHHNBChildrenDropSchoolLivingM.Text
            eInsuree.HHNBChildrenDropSchoolLivingF = txtHHNBChildrenDropSchoolLivingF.Text
            eInsuree.HHNBChildrenDropSchoolLivingT = txtHHNBChildrenDropSchoolLivingT.Text
            eInsuree.HHNBGirlsMarried = txtHHNBGirlsMarried.Text
            eInsuree.HHNBChildrenBirthCertifM = txtHHNBChildrenBirthCertifM.Text
            eInsuree.HHNBChildrenBirthCertifF = txtHHNBChildrenBirthCertifF.Text
            eInsuree.HHNBChildrenBirthCertifT = txtHHNBChildrenBirthCertifT.Text
            If ddlHHHealthStatus.SelectedValue <> "" Then eInsuree.HHHealthStatus = ddlHHHealthStatus.SelectedValue
            eInsuree.HHExpenditure = txtHHExpenditure.Text
            eInsuree.HHExpenditurePerH = txtHHExpenditurePerH.Text
            If ddlHHNutritionalStatus.SelectedValue <> "" Then eInsuree.HHNutritionalStatus = ddlHHNutritionalStatus.SelectedValue
            If ddlHHMentalPhysicalDisability.SelectedValue <> "" Then eInsuree.HHMentalPhysicalDisability = ddlHHMentalPhysicalDisability.SelectedValue
            eInsuree.HHMentalPhysicalDisabilityM = txtHHMentalPhysicalDisabilityM.Text
            eInsuree.HHMentalPhysicalDisabilityF = txtHHMentalPhysicalDisabilityF.Text
            eInsuree.HHMentalPhysicalDisabilityT = txtHHMentalPhysicalDisabilityT.Text
            If chkHHMentalPhysicalDisabilityO1.Checked Then
                eInsuree.HHMentalPhysicalDisabilityO1 = True
            Else
                eInsuree.HHMentalPhysicalDisabilityO1 = False
            End If
            If chkHHMentalPhysicalDisabilityO2.Checked Then
                eInsuree.HHMentalPhysicalDisabilityO2 = True
            Else
                eInsuree.HHMentalPhysicalDisabilityO2 = False
            End If
            If chkHHMentalPhysicalDisabilityO3.Checked Then
                eInsuree.HHMentalPhysicalDisabilityO3 = True
            Else
                eInsuree.HHMentalPhysicalDisabilityO3 = False
            End If
            eInsuree.HHMentalPhysicalDisabilityO4 = txtHHMentalPhysicalDisabilityO4.Text
            eInsuree.Relationship = ddlRelationship.SelectedValue
            eInsuree.ChildGender = ddlChildGender.SelectedValue
            If txtBirthDateChild.Text.Length > 0 Then
                eInsuree.BirthDateChild = Date.ParseExact(txtBirthDateChild.Text, "dd/MM/yyyy", Nothing)
            Else
                eInsuree.BirthDateChild = Date.ParseExact("01/01/1900", "dd/MM/yyyy", Nothing)
            End If
            If chkDateInconnueChild.Checked Then
                eInsuree.DateInconnueChild = True
            Else
                eInsuree.DateInconnueChild = False
            End If
            eInsuree.CHBirthCertificate = ddlCHBirthCertificate.SelectedValue
            eInsuree.CHEnrolmentStatus = ddlCHEnrolmentStatus.SelectedValue
            eInsuree.ChildSchoolName = txtChildSchoolName.Text
            eInsuree.CHEnrolmentWhichClass = ddlCHEnrolmentWhichClass.SelectedValue
            eInsuree.CHEnrolmentScore = ddlCHEnrolmentScore.SelectedValue
            eInsuree.CHEnrolmentOutofSchool = ddlCHEnrolmentOutofSchool.SelectedValue
            eInsuree.CHParentalStatus = ddlCHParentalStatus.SelectedValue

            If chkResidentialStatus1.Checked Then
                eInsuree.ResidentialStatus1 = True
            Else
                eInsuree.ResidentialStatus1 = False
            End If
            If chkResidentialStatus2.Checked Then
                eInsuree.ResidentialStatus2 = True
            Else
                eInsuree.ResidentialStatus2 = False
            End If
            If chkResidentialStatus3.Checked Then
                eInsuree.ResidentialStatus3 = True
            Else
                eInsuree.ResidentialStatus3 = False
            End If
            If chkResidentialStatus4.Checked Then
                eInsuree.ResidentialStatus4 = True
            Else
                eInsuree.ResidentialStatus4 = False
            End If
            If chkResidentialStatus5.Checked Then
                eInsuree.ResidentialStatus5 = True
            Else
                eInsuree.ResidentialStatus5 = False
            End If
            If chkResidentialStatus6.Checked Then
                eInsuree.ResidentialStatus6 = True
            Else
                eInsuree.ResidentialStatus6 = False
            End If
            If chkResidentialStatus7.Checked Then
                eInsuree.ResidentialStatus7 = True
            Else
                eInsuree.ResidentialStatus7 = False
            End If


            If chkCHSpecialNeeds1.Checked Then
                eInsuree.CHSpecialNeeds1 = True
            Else
                eInsuree.CHSpecialNeeds1 = False
            End If
            If chkCHSpecialNeeds2.Checked Then
                eInsuree.CHSpecialNeeds2 = True
            Else
                eInsuree.CHSpecialNeeds2 = False
            End If
            If chkCHSpecialNeeds3.Checked Then
                eInsuree.CHSpecialNeeds3 = True
            Else
                eInsuree.CHSpecialNeeds3 = False
            End If
            If chkCHSpecialNeeds4.Checked Then
                eInsuree.CHSpecialNeeds4 = True
            Else
                eInsuree.CHSpecialNeeds4 = False
            End If
            If chkCHSpecialNeeds5.Checked Then
                eInsuree.CHSpecialNeeds5 = True
            Else
                eInsuree.CHSpecialNeeds5 = False
            End If
            eInsuree.CHSpecialNeeds6 = txtCHSpecialNeeds6.Text
            eInsuree.ChildName = txtChildName.Text



            '''fin traitement ajout champs
            eInsuree.Gender = ddlGender.SelectedValue
            If ddlMarital.SelectedValue <> "" Then eInsuree.Marital = ddlMarital.SelectedValue
            If ddlCardIssued.SelectedValue.Length > 0 Then eInsuree.CardIssued = ddlCardIssued.SelectedValue
            eInsuree.passport = txtPassport.Text
            eInsuree.Phone = txtPhone.Text
            eInsuree.AltPhone = txtAltPhone.Text
            eInsuree.Email = txtEmail.Text
            If ddlProfession.SelectedValue > 0 Then
                eInsuree.Profession = ddlProfession.SelectedValue
            End If
            If ddlEducation.SelectedIndex > 0 Then
                eInsuree.Education = ddlEducation.SelectedValue
            End If
            eInsuree.isOffline = IMIS_Gen.offlineHF Or IMIS_Gen.OfflineCHF
            ePhotos.PhotoID = 0
            ePhotos.InsureeID = eInsuree.InsureeID
            ePhotos.CHFID = eInsuree.CHFID.Trim
            ePhotos.PhotoFolder = IMIS_EN.AppConfiguration.UpdatedFolder

            If ddlType.SelectedValue <> "" Then eFamily.FamilyType = ddlType.SelectedValue
            eFamily.FamilyAddress = txtAddress.Text
            eFamily.ConfirmationNo = txtConfirmationNo.Text

            Dim ImageName As String = Mid(Image1.ImageUrl, Image1.ImageUrl.LastIndexOf("\") + 2, Image1.ImageUrl.Length)

            ePhotos.PhotoFileName = ImageName


            If ImageName.Length > 0 Then
                ePhotos.OfficerID = Family.getOfficerID(ImageName)
            End If

            If ImageName.Length > 0 Then
                ePhotos.ValidityFrom = Family.ExtractDate(ImageName)
            End If

            ePhotos.AuditUserID = dt.Rows(0)("UserID")

            If ImageName.Length > 0 Then
                eInsuree.PhotoDate = Now
            Else
                eInsuree.PhotoDate = System.Data.SqlTypes.SqlDateTime.Null
            End If

            ePhotos.PhotoDate = eInsuree.PhotoDate

            'Addition for Nepal >> Start
            If ddlIdType.SelectedIndex > 0 Then eInsuree.TypeOfId = ddlIdType.SelectedValue
            Dim eHF As New IMIS_EN.tblHF
            If ddlFSP.Items.Count > 0 AndAlso ddlFSP.SelectedValue > 0 Then
                eHF.HfID = ddlFSP.SelectedValue
            End If
            eInsuree.tblHF = eHF

            eInsuree.CurrentAddress = txtCurrentAddress.Text
            If ddlCurDistrict.SelectedIndex > 0 Then eInsuree.CurDistrict = ddlCurDistrict.SelectedValue
            If ddlCurVDC.SelectedValue.Length > 0 Then eInsuree.CurWard = ddlCurVDC.SelectedValue
            If ddlCurWard.SelectedValue.Length > 0 Then eInsuree.CurrentVillage = ddlCurWard.SelectedValue

            If ImageName.Length > 0 Then
                eInsuree.GeoLocation = Family.ExtractLatitude(ImageName) & " " & Family.ExtractLongitude(ImageName)
            End If
            'Addition for Nepal >> End

            eFamily.AuditUserID = dt.Rows(0)("UserID")
            eFamily.isOffline = IMIS_Gen.offlineHF Or IMIS_Gen.OfflineCHF
            eInsuree.tblPhotos = ePhotos
            eFamily.tblInsuree = eInsuree

            Family.SaveFamily(eFamily)

            If Image1.ImageUrl.Length > 0 Then
                '  If Not ePhotos.PhotoFolder.Contains(IMIS_EN.AppConfiguration.UpdatedFolder) Then
                UpdateImage(ePhotos)
                'End If
            End If

        Catch ex As Exception
            'lblMsg.Text = imisgen.getMessage("M_ERRORMESSAGE")
            imisgen.Alert(imisgen.getMessage("M_ERRORMESSAGE"), pnlBody, alertPopupTitle:="IMIS")
            imisgen.Log(Page.Title & " : " & imisgen.getLoginName(Session("User")), ex)
            'EventLog.WriteEntry("IMIS", Page.Title & " : " & imisgen.getLoginName(Session("User")) & " : " & ex.Message, EventLogEntryType.Error, 999)
            Return
        End Try

        FamilyUUID = Family.GetFamilyUUIDByID(eFamily.FamilyID)

        Response.Redirect("OverviewFamily.aspx?f=" & FamilyUUID.ToString())

    End Sub

    Protected Sub chkDateInconnue_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        If chkDateInconnue.Checked Then
            changeEnabledValidatorFieldsDob(False)
        Else
            changeEnabledValidatorFieldsDob(True)
        End If
    End Sub
    Private Sub changeEnabledValidatorFieldsDob(ByVal enabled As Boolean)
        RequiredFieldBirthDate0.Enabled = enabled
    End Sub
    Protected Sub chkDateInconnueChild_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        If chkDateInconnueChild.Checked Then
            changeEnabledValidatorFieldsDobChild(False)
        Else
            changeEnabledValidatorFieldsDobChild(True)
        End If
    End Sub
    Private Sub changeEnabledValidatorFieldsDobChild(ByVal enabled As Boolean)
        RequiredFieldBirthDate1.Enabled = enabled
    End Sub

    Private Sub B_CANCEL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B_CANCEL.Click

        If Not eFamily.FamilyID = 0 And B_SAVE.Visible Then
            FamilyUUID = Family.GetFamilyUUIDByID(eFamily.FamilyID)
            Response.Redirect("OverviewFamily.aspx?f=" & FamilyUUID.ToString())
        Else
            Response.Redirect("FindFamily.aspx")
        End If
    End Sub
    Protected Sub dlImages_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dlImages.SelectedIndexChanged
        Image1.ImageUrl = IMIS_EN.AppConfiguration.SubmittedFolder & (dlImages.SelectedValue)
    End Sub
    Private Sub UpdateImage(ByRef ePhotos As IMIS_EN.tblPhotos)
        Dim Insuree As New IMIS_BI.InsureeBI
        Insuree.UpdateImage(ePhotos, False)
        Image1.ImageUrl = IMIS_EN.AppConfiguration.UpdatedFolder & Mid(Image1.ImageUrl, Image1.ImageUrl.LastIndexOf("\") + 2, Image1.ImageUrl.Length)
    End Sub
    Protected Sub txtCHFID_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCHFID.TextChanged
        Try
            eInsuree.CHFID = txtCHFID.Text.Trim
            eInsuree.isOffline = IMIS_Gen.offlineHF Or IMIS_Gen.OfflineCHF
            If Family.CheckCHFID(txtCHFID.Text) = True Then
                FetchNewImage()
                FillImageDL()
            End If
        Catch ex As Exception
            'lblMsg.Text = imisgen.getMessage("M_ERRORMESSAGE")
            imisgen.Alert(imisgen.getMessage("M_ERRORMESSAGE"), pnlBody, alertPopupTitle:="IMIS")
            imisgen.Log(Page.Title & " : " & imisgen.getLoginName(Session("User")), ex)
            'EventLog.WriteEntry("IMIS", Page.Title & " : " & imisgen.getLoginName(Session("User")) & " : " & ex.Message, EventLogEntryType.Error, 999)
            Return
        End Try

    End Sub
    Private Sub ddlFSPDistrict_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlFSPDistrict.SelectedIndexChanged
        Try
            FillHF()
        Catch ex As Exception
            imisgen.Alert(imisgen.getMessage("M_ERRORMESSAGE"), pnlBody, alertPopupTitle:="IMIS")
            imisgen.Log(Page.Title & " : " & imisgen.getLoginName(Session("User")), ex)
            'EventLog.WriteEntry("IMIS", Page.Title & " : " & imisgen.getLoginName(Session("User")) & " : " & ex.Message, EventLogEntryType.Error, 999)
        End Try
    End Sub
    Private Sub ddlFSPCateogory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlFSPCateogory.SelectedIndexChanged
        Try
            FillHF()
        Catch ex As Exception
            imisgen.Alert(imisgen.getMessage("M_ERRORMESSAGE"), pnlBody, alertPopupTitle:="IMIS")
            imisgen.Log(Page.Title & " : " & imisgen.getLoginName(Session("User")), ex)
            'EventLog.WriteEntry("IMIS", Page.Title & " : " & imisgen.getLoginName(Session("User")) & " : " & ex.Message, EventLogEntryType.Error, 999)
        End Try
    End Sub

    Private Sub ddlCurDistrict_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCurDistrict.SelectedIndexChanged
        Try
            GetCurVillages()
        Catch ex As Exception
            imisgen.Alert(imisgen.getMessage("M_ERRORMESSAGE"), pnlButtons, alertPopupTitle:="IMIS")
            imisgen.Log(Page.Title & " : " & imisgen.getLoginName(Session("User")), ex)
            'EventLog.WriteEntry("IMIS", Page.Title & " : " & imisgen.getLoginName(Session("User")) & " : " & ex.Message, EventLogEntryType.Error, 999)
        End Try
    End Sub

    Private Sub ddlCurVDC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCurVDC.SelectedIndexChanged
        getCurWards()
    End Sub

    Private Sub ddlRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlRegion.SelectedIndexChanged
        FillDistricts()
    End Sub

    Private Sub ddlFSPRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlFSPRegion.SelectedIndexChanged
        FillFSPDistricts()
    End Sub

    Private Sub ddlCurrentRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCurrentRegion.SelectedIndexChanged
        FillCurrentDistricts()
    End Sub
    Private Sub FillCurrentDistricts()
        Dim dtCurDistrict As DataTable = Family.GetDistrictsAll(imisgen.getUserId(Session("User")), Val(ddlCurrentRegion.SelectedValue), True)
        ddlCurDistrict.DataSource = dtCurDistrict
        ddlCurDistrict.DataValueField = "DistrictId"
        ddlCurDistrict.DataTextField = "DistrictName"
        ddlCurDistrict.DataBind()

        If dtCurDistrict.Rows.Count = 1 Then
            getWards()
        End If

    End Sub
End Class
