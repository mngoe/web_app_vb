<%-- Copyright (c) 2016-2017 Swiss Agency for Development and Cooperation (SDC)

The program users must agree to the following terms:

Copyright notices
This program is free software: you can redistribute it and/or modify it under the terms of the GNU AGPL v3 License as published by the 
Free Software Foundation, version 3 of the License.
This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU AGPL v3 License for more details www.gnu.org.

Disclaimer of Warranty
There is no warranty for the program, to the extent permitted by applicable law; except when otherwise stated in writing the copyright 
holders and/or other parties provide the program "as is" without warranty of any kind, either expressed or implied, including, but not 
limited to, the implied warranties of merchantability and fitness for a particular purpose. The entire risk as to the quality and 
performance of the program is with you. Should the program prove defective, you assume the cost of all necessary servicing, repair or correction.

Limitation of Liability 
In no event unless required by applicable law or agreed to in writing will any copyright holder, or any other party who modifies and/or 
conveys the program as permitted above, be liable to you for damages, including any general, special, incidental or consequential damages 
arising out of the use or inability to use the program (including but not limited to loss of data or data being rendered inaccurate or losses 
sustained by you or third parties or a failure of the program to operate with any other programs), even if such holder or other party has been 
advised of the possibility of such damages.

In case of dispute arising out or in relation to the use of the program, it is subject to the public law of Switzerland. The place of jurisdiction is Berne.--%>
<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Family.aspx.vb" MasterPageFile="~/IMIS.Master" Inherits="IMIS.Family" Title='<%$ Resources:Resource,L_ADDFAMILY %>' %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="cHead" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #SelectPic {
            padding-top: 10%;
            width: 100%;
            margin: auto;
            text-align: center;
            vertical-align: bottom;
            position: fixed;
            top: 0;
            left: 0;
            height: 100%;
            z-index: 1001;
            background-color: Gray;
            opacity: 0.9;
            display: none;
        }
        .auto-style1 {
            height: 27px;
            width: 150px;
            text-align: right;
            color: Blue;
            font-weight: normal;
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            padding-right: 1px;
        }
        .auto-style2 {
            height: 27px;
        }
    </style>
    <script type="text/javascript" language="javascript">


        function pageLoadExtend() {
            $(document).ready(function () {

                $('#<%=btnBrowse.ClientID %>').click(function (e) {

                    $("#SelectPic").show();

                    e.preventDefault();
                });
                var chk = document.getElementById('<%= chkDateInconnue.ClientID %>');
                if (chk.checked) {
                    dobInfoValidation(false);
                    toggleDobrInfoForm(false);
                } else {
                    dobInfoValidation(true);
                    toggleDobrInfoForm(true);
                }
                var chk = document.getElementById('<%= chkDateInconnueChild.ClientID %>');
                if (chk.checked) {
                    dobChildInfoValidation(false);
                    toggleDobChildInfoForm(false);
                } else {
                    dobChildInfoValidation(true);
                    toggleDobChildInfoForm(true);
                }

            });
        }

        $(document).ready(function () {

            $("#btnCancel").hide();
            $('#<%=btnBrowse.ClientID %>').click(function (e) {

            $("#SelectPic").show();
            $("#btnCancel").show();
            e.preventDefault();
        });



        $("#btnCancel").click(function () {
            //alert('called');
            $("#SelectPic").hide();
            $("#btnCancel").hide();
        });




    }); 
    function fireCheckChanged() { 
        var chk = document.getElementById('<%= chkDateInconnue.ClientID %>');
        if (chk.checked) {
            dobInfoValidation(false);
            toggleDobrInfoForm(false);
        } else {
            dobInfoValidation(true);
            toggleDobrInfoForm(true);
        }
        var chk = document.getElementById('<%= chkDateInconnueChild.ClientID %>');
        if (chk.checked) {
            dobChildInfoValidation(false);
            toggleDobChildInfoForm(false);
        } else {
            dobChildInfoValidation(true);
            toggleDobChildInfoForm(true);
        }
    };
    
    function dobInfoValidation(value) {
        ValidatorEnable(document.getElementById("<%=RequiredFieldBirthDate0.ClientID %>"), value);
    }

    function toggleDobrInfoForm(visible) {
        var dob = document.getElementById("date_naissance");
        if (visible) {
            dob.style.display = "";
        }else{
            dob.style.display = "none";
        }
    }
    function dobChildInfoValidation(value) {
        ValidatorEnable(document.getElementById("<%=RequiredFieldBirthDate1.ClientID %>"), value);
    }
    function toggleDobChildInfoForm(visible) {
        var dob = document.getElementById("date_naissance_enfant");
        if (visible) {
            dob.style.display = "";
        }else{
            dob.style.display = "none";
        }
    }
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Body" Runat="Server">
    <div class="divBody" >

    <asp:Panel ID='panebody' runat="server" CssClass="panelBody" Style="height: auto;">
        <asp:Panel ID="PanelLocation" runat="server" CssClass="panel" GroupingText='<%$ Resources:Resource,L_LOCATIONINFO_ %>' EnableTheming="True" >
            <asp:UpdatePanel ID="upCurentLocalisation" runat="server"  >                                
               <ContentTemplate>      
                  <table >
                    <tr id="trCurrentRegion" runat="server">
                        <td class="FormLabel">
                            <asp:Label ID="lblCurrentRegion" runat="server" Text="<%$ Resources:Resource, L_CREGION %>"></asp:Label>
                        </td>
                        <td class="DataEntry">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCurrentRegion" Width="150px" runat="server" AutoPostBack="True">

                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfCurrentRegion" runat="server" ControlToValidate="ddlCurrentRegion" InitialValue="0" SetFocusOnError="True" style="direction: ltr" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                         Text='*'></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="FormLabel">&nbsp;</td>
                        <td class="DataEntry">&nbsp;</td>
                    </tr>
                    <tr id="trCurrentDistrict" runat="server">
                        <td class="FormLabel">
                            <asp:Label ID="lblCurrentDistrict0" runat="server" Text="<%$ Resources:Resource, L_CDISTRICT %>"></asp:Label>
                        </td>
                        <td class="DataEntry">
                            <asp:UpdatePanel ID="upCurDistrict" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCurDistrict" runat="server" Width="150px" AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfCurrentDistrict" runat="server" ControlToValidate="ddlCurDistrict" InitialValue="0" SetFocusOnError="True" Style="direction: ltr" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                    Text='*'></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td></td>
                        <td class="DataEntry">&nbsp;</td>
                    </tr>
                    <tr id="trCurrentMunicipality" runat="server">
                        <td class="FormLabel">
                            <asp:Label ID="lblCurrentVDC0" runat="server" Text="<%$ Resources:Resource, L_CVDC %>"></asp:Label>
                        </td>
                        <td class="DataEntry">
                            <asp:UpdatePanel ID="upCurVDC" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCurVDC" runat="server" Width="150px" AutoPostBack="True"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfCurrentVDC" runat="server" ControlToValidate="ddlCurVDC" InitialValue="0" SetFocusOnError="True" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                    Text='*'></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td></td>
                        <td class="DataEntry">&nbsp;</td>
                    </tr>
                    <tr id="trCurrentVillage" runat="server">
                        <td class="FormLabel">
                            <asp:Label ID="lblCurrentWard0" runat="server" Text="<%$ Resources:Resource, L_CWARD %>"></asp:Label>
                        </td>
                        <td class="DataEntry">
                            <asp:UpdatePanel ID="upCurWard" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCurWard" runat="server" Width="150px"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfCurrentVillage" runat="server" ControlToValidate="ddlCurWard" InitialValue="0" SetFocusOnError="True" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                    Text='*'></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td></td>
                        <td class="DataEntry">&nbsp;</td>
                    </tr>
                </table>    
                                           
               </ContentTemplate>      
            </asp:UpdatePanel>                      
        </asp:Panel>
        
        <asp:Panel ID="pnlBody" runat="server" CssClass="panelBody" GroupingText='<%$ Resources:Resource,L_HEADHOUSEINFO_%>'>
            <asp:UpdatePanel ID="upCHFID" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td class="FormLabel">
                                <asp:Label ID="L_CHFID" runat="server" Text="<%$ Resources:Resource,L_CHFID%>">
                                </asp:Label>
                            </td>
                            <td class="DataEntry">
                                <asp:TextBox ID="txtCHFID" runat="server" AutoPostBack="True" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldCHFID0" runat="server" ControlToValidate="txtCHFID" SetFocusOnError="True" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                        Text='*'>
                                </asp:RequiredFieldValidator>
                            </td>
                            <td class="FormLabel">
                                <asp:Label ID="L_PHONE" runat="server" Text="<%$ Resources:Resource,L_PHONE%>">
                                </asp:Label>
                            </td>
                            <td class="DataEntry">
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                            </td>
                            <td class="FormLabel">
                                <asp:Label ID="L_IDTYPE" runat="server" Text="<%$ Resources:Resource, L_IDTYPE %>"></asp:Label>
                            </td>
                            <td class="DataEntry">
                                <asp:DropDownList ID="ddlIdType" runat="server" Width="150px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfIdType" runat="server" ControlToValidate="ddlIdType" InitialValue="" SetFocusOnError="True" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                        Text='*'></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="FormLabel">
                                <asp:Label ID="L_OTHERNAMES0" runat="server" Text="<%$ Resources:Resource,L_OTHERNAMES %>">
                                </asp:Label>
                            </td>
                            <td class="DataEntry">
                                <asp:TextBox ID="txtOtherNames" runat="server"   MaxLength="100" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldOtherNames1" runat="server" ControlToValidate="txtOtherNames" SetFocusOnError="True" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                        Text='*'>
                                </asp:RequiredFieldValidator>
                            </td>
                            <td class="FormLabel">
                                <asp:Label ID="L_NETWORKPROVIDER1" runat="server" Text="<%$ Resources:Resource,L_NETWORKPROVIDER%>">
                                </asp:Label>
                            </td>
                            <td class="DataEntry">
                                <asp:DropDownList ID="ddlNetWorkProvider1" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td class="FormLabel">
                                <asp:Label ID="L_PASSPORT" runat="server" Text="<%$ Resources:Resource,L_PASSPORT%>">
                                </asp:Label>
                            </td>
                            <td class="DataEntry">
                                <asp:TextBox ID="txtPassport" runat="server" MaxLength="25" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfIdNo1" runat="server" ControlToValidate="txtPassport" InitialValue="" SetFocusOnError="True" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                        Text='*'></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="FormLabel">
                                <asp:Label ID="L_LASTNAME0" runat="server" Text="<%$ Resources:Resource,L_LASTNAME %>">
                                </asp:Label>
                            </td>
                            <td class="DataEntry">
                                <asp:TextBox ID="txtLastName" runat="server"   MaxLength="100" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldLastName2" runat="server" ControlToValidate="txtLastName" SetFocusOnError="True" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                        Text='*'>
                                </asp:RequiredFieldValidator>
                            </td>
                            <td class="FormLabel">
                                <asp:Label ID="L_HEADPHONE" runat="server" Text="<%$ Resources:Resource,L_HEADPHONE%>">
                                </asp:Label>
                            </td>
                            <td class="DataEntry">
                                <asp:CheckBox ID="chkIsHeadPhone1" runat="server"
                                ForeColor="Blue"/>
                            </td>
                            <td class="FormLabel">
                                <asp:Label ID="L_PREFEREDMONEYTRANSFERTMODE" runat="server" Text="<%$ Resources:Resource,L_PREFEREDMONEYTRANSFERTMODE%>">
                                </asp:Label>
                            </td>
                            <td class="DataEntry">
                                <asp:DropDownList ID="ddlPreferredPaiementMode" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="FormLabel">
                                <asp:Label ID="L_GENDER" runat="server" Text="<%$ Resources:Resource,L_GENDER %>">
                                </asp:Label>
                            </td>
                            <td class="DataEntry">
                                <asp:DropDownList ID="ddlGender" runat="server" Width="150px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldGender0" runat="server" ControlToValidate="ddlGender" InitialValue="" SetFocusOnError="True" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                        Text='*'></asp:RequiredFieldValidator>
                            </td>
                            <td class="FormLabel">
                                <asp:Label ID="L_ALTPHONE" runat="server" Text="<%$ Resources:Resource,L_ALTPHONE%>">
                                </asp:Label>
                            </td>
                            <td class="DataEntry">
                                <asp:TextBox ID="txtAltPhone" CssClass="numbersOnly" MaxLength="12" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="trMaritalStatus" runat="server">
                            <td class="FormLabel">
                                <asp:Label ID="L_MARITAL" runat="server" Text="<%$ Resources:Resource,L_MARITAL %>">
                                </asp:Label>
                            </td>
                            <td class="DataEntry">
                                <asp:DropDownList ID="ddlMarital" runat="server" Width="150px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfMaritalStatus" runat="server" ControlToValidate="ddlMarital" InitialValue="" SetFocusOnError="True" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                        Text='*'></asp:RequiredFieldValidator>
                            </td>
                            <td class="FormLabel">
                                <asp:Label ID="L_NETWORKPROVIDER2" runat="server" Text="<%$ Resources:Resource,L_NETWORKPROVIDER%>">
                                </asp:Label>
                            </td>
                            <td class="DataEntry">
                                <asp:DropDownList ID="ddlNetWorkProvider2" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr id="trCurrentAddress" runat="server">
                            <td class="FormLabel" style="vertical-align: top">
                                <asp:Label ID="lblCurrentAddress0" runat="server" Text="<%$ Resources:Resource, L_CURRENTADDRESS %>"></asp:Label>
                            </td>
                            <td class="DataEntry">
                                <asp:TextBox ID="txtCurrentAddress" runat="server" Height="40px" MaxLength="25" Style="resize: none;" TextMode="MultiLine" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfCurrentAddress" runat="server" ControlToValidate="txtCurrentAddress" SetFocusOnError="True" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                        Text='*'></asp:RequiredFieldValidator>
                            </td>
                            <td class="FormLabel">
                                <asp:Label ID="L_ALTHEADPHONE" runat="server" Text="<%$ Resources:Resource,L_ALTHEADPHONE%>">
                                </asp:Label>
                            </td>
                            <td class="DataEntry">
                                <asp:CheckBox ID="chkIsHeadPhone2" runat="server"
                                ForeColor="Blue"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="FormLabel">
                                <asp:Label ID="L_BIRTHDATEINCONNU" runat="server" Text="<%$ Resources:Resource,L_BIRTHDATEINCONNU %>">
                                </asp:Label>
                            </td>
                            <td class="DataEntry">
                                <asp:CheckBox ID="chkDateInconnue" runat="server" OnCheckedChanged="chkDateInconnue_CheckedChanged" onclick="fireCheckChanged()" 
                                    ForeColor="Blue"/> 
                            </td>
                        </tr>
                        <tr id="date_naissance">
                            <td class="FormLabel">
                                <asp:Label ID="L_BIRTHDATE" runat="server" Text="<%$ Resources:Resource,L_BIRTHDATE %>">
                                </asp:Label>
                            </td>
                            <td class="DataEntry">
                                <asp:TextBox ID="txtBirthDate" runat="server" Width="132px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="Button1" TargetControlID="txtBirthDate">
                                </asp:CalendarExtender>
                                <asp:Button ID="Button1" runat="server" Height="20px" Width="20px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldBirthDate0" runat="server" ControlToValidate="txtBirthDate" SetFocusOnError="False" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                        Text='*'></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtBirthDate" ErrorMessage="*" SetFocusOnError="false" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/](19|20)\d\d$" ValidationGroup="check" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:UpdatePanel ID="upDL" runat="server">
            <ContentTemplate>
                <table id="SelectPic">
                    <tr>
                        <td align="center">
                        <asp:Panel ID="pnlImages" runat="server" Width="500px" Height="450px" BackColor="White" ScrollBars="Auto">
                            <asp:DataList ID="dlImages" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" DataKeyField="ImagePath" OnSelectedIndexChanged="dlImages_SelectedIndexChanged"> 
                                <ItemTemplate>
                                    <table width="100px" style="height:100px">
                                        <tr>
                                            <td align="center">
                                                On: <%#Eval("TakenDate")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img alt="" width="100px" height="100px" src='Images\Submitted\<%#eval("ImagePath") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select">Select</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate> 
                                </asp:DataList>                                                     
                        </asp:Panel>
                        <br />  
                        <input type="button" id="btnCancel" value="Cancel" />
                        </td>
                    </tr>
                </table>    
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Panel ID="headHouseholdInformation" runat="server" Style="height: auto;" CssClass="panelBody" GroupingText='<%$ Resources:Resource,L_HOUSEVULNERABILITY_%>'>
            <ContentTemplate>
                <br/>
                <hr/>
                <table>
                    <%--Prenier Bloc pour assuré enfant--%>
                    <tr id="trProfession" runat="server">
                        <td class="FormLabel" style="white-space:nowrap;">
                            <asp:Label ID="L_PROFESSION0" runat="server" Text="<%$ Resources:Resource, L_PROFESSION %>"></asp:Label>
                        </td>
                        <td class="DataEntry">
                            <asp:DropDownList ID="ddlProfession" runat="server" Width="150px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfProfession" runat="server" ControlToValidate="ddlProfession" InitialValue="0" SetFocusOnError="True" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                    Text='*'></asp:RequiredFieldValidator>
                        </td>
                        <td class="FormLabel" style="white-space:nowrap;">
                            <asp:Label
                                ID="L_REGION"
                                runat="server"
                                Text='<%$ Resources:Resource,L_REGIONORIGIN %>'></asp:Label>
                        </td>
                        <td class="DataEntry">
                            <asp:DropDownList ID="ddlRegion" runat="server" Width="150px" AutoPostBack="true" />
                            <asp:RequiredFieldValidator ID="RequiredFieldRegion" runat="server"
                                ControlToValidate="ddlRegion" InitialValue="0"
                                SetFocusOnError="True"
                                ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                    Text='*'></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id="trEducation" runat="server">
                        <td class="FormLabel" style="white-space:nowrap;">
                            <asp:Label ID="L_EDUCATION0" runat="server" Text="<%$ Resources:Resource, L_EDUCATION %>"></asp:Label>
                        </td>
                        <td class="DataEntry">
                            <asp:DropDownList ID="ddlEducation" runat="server" Width="150px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfEducation" runat="server" ControlToValidate="ddlEducation" InitialValue="0" SetFocusOnError="True" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                    Text='*'></asp:RequiredFieldValidator>
                        </td>
                        <td class="FormLabel" style="white-space:nowrap;">
                            <asp:Label ID="L_DISTRICT" runat="server" Text="<%$ Resources:Resource,L_DISTRICTORIGIN %>"></asp:Label>
                        </td>
                        <td class="DataEntry">
                            <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" Width="150px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldDistrict" runat="server" ControlToValidate="ddlDistrict" InitialValue="0" SetFocusOnError="True" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                    Text='*'></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="FormLabel" style="white-space:nowrap;">
                            <asp:Label
                                ID="L_HEADSTATUS"
                                runat="server"
                                Text='<%$ Resources:Resource,L_HEADSTATUS %>'></asp:Label>
                        </td>
                        <td class="DataEntry">
                            <asp:DropDownList ID="ddlHeadStatus" runat="server" Width="150px"/>
                        </td>
                        <td class="FormLabel" style="white-space:nowrap;">
                            <asp:Label 
                                ID="L_WARD"
                                runat="server" 
                                Text='<%$ Resources:Resource,L_WARDORIGIN %>'>
                            </asp:Label>
                        </td>
                        <td class="DataEntry">
                            <asp:DropDownList ID="ddlWard" runat="server" Width="150px" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator 
                                ID="RequiredFieldWard" 
                                runat="server" 
                                ControlToValidate="ddlWard" 
                                InitialValue="0"
                                ErrorMessage="Please select a Ward." 
                                SetFocusOnError="True" 
                                ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                        Text='*'></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator 
                                ID="RequiredFieldWard1" 
                                runat="server" 
                                ControlToValidate="ddlWard" 
                                    ErrorMessage="Please select a Ward." 
                                SetFocusOnError="True" 
                                ValidationGroup="check" ForeColor="Red"  Display="Dynamic"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="FormLabel" style="white-space:nowrap;">
                            <asp:Label
                                ID="L_LENGTHSTAYLOCATION"
                                runat="server"
                                Text='<%$ Resources:Resource,L_LENGTHSTAYLOCATION %>'></asp:Label>
                        </td>
                        <td class="DataEntry">
                            <asp:DropDownList ID="ddlLengthPresentLocation" runat="server" Width="150px"/>
                        </td>
                        <td class="FormLabel" style="white-space:nowrap;">
                            <asp:Label 
                                ID="L_VILLAGE"
                                runat="server" 
                                Text='<%$ Resources:Resource,L_VILLAGEORIGIN %>'>
                            </asp:Label>
                        </td>
                        <td class="DataEntry">
                            <asp:DropDownList 
                                ID="ddlVillage" 
                                runat="server" 
                                Width="150px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator 
                                ID="RequiredFieldVillage" 
                                runat="server" 
                                ControlToValidate="ddlVillage" 
                                InitialValue="0" 
                                SetFocusOnError="True" 
                                ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                        Text='*'></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator 
                                ID="RequiredFieldVillage1" 
                                runat="server" 
                                ControlToValidate="ddlVillage" 
                                    SetFocusOnError="True" 
                                ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <td class="FormLabel">
                            <asp:Label ID="L_ADDRESS" runat="server"
                                Text="<%$ Resources:Resource, L_PARMANENTADDRESS %>" Style="direction: ltr"></asp:Label>
                        </td>
                        <td class="DataEntry">
                            <asp:TextBox ID="txtAddress" runat="server" Height="40px" MaxLength="25"
                                TextMode="MultiLine" Width="150px" Style="resize: none;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfAddress" runat="server" ControlToValidate="txtAddress" SetFocusOnError="True" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                    Text='*'></asp:RequiredFieldValidator>
                        </td>
                        
                    </tr>
                </table>
                <hr/>
                <table>
                    <%--2ieme Bloc pour assuré enfant--%>
                    <tr>
                        <td class="DataEntry">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_MALELIVINGHOUSHOLD" runat="server" Text="<%$ Resources:Resource,L_MALELIVINGHOUSHOLD%>">
                            </asp:Label>
                            <asp:TextBox ID="txtMaleLivingHoushold" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_FEMALELIVINGHOUSHOLD" runat="server" Text="<%$ Resources:Resource,L_FEMALELIVINGHOUSHOLD%>">
                            </asp:Label>
                            <asp:TextBox ID="txtFemaleLivingHoushold" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_PERSONLIVINGHOUSHOLD" runat="server" Text="<%$ Resources:Resource,L_PERSONLIVINGHOUSHOLD%>">
                            </asp:Label>
                            <asp:TextBox ID="txtPersonLivingHoushold" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <hr/>
                <table>
                    <%--3ieme Bloc pour assuré enfant--%>
                    <tr>
                        <td class="DataEntry">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHNBChildrenLivingM" runat="server" Text="<%$ Resources:Resource,L_HHNBChildrenLivingM %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHNBChildrenLivingM" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHNBChildrenLivingFemale" runat="server" Text="<%$ Resources:Resource,L_HHNBChildrenLivingFemale %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHNBChildrenLivingF" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHNBChildrenLivingTotal" runat="server" Text="<%$ Resources:Resource,L_HHNBChildrenLivingTotal %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHNBChildrenLivingT" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <hr/>
                <table>
                    <%--4ieme Bloc pour assuré enfant--%>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHNBChildrenSchoolLivingM" runat="server" Text="<%$ Resources:Resource,L_HHNBChildrenSchoolLivingM %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHNBChildrenSchoolLivingM" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHNBChildrenSchoolLivingF" runat="server" Text="<%$ Resources:Resource,L_HHNBChildrenSchoolLivingF %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHNBChildrenSchoolLivingF" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHNBChildrenSchoolLivingTotal" runat="server" Text="<%$ Resources:Resource,L_HHNBChildrenSchoolLivingTotal %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHNBChildrenSchoolLivingT" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <hr/>
                <table>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHNBChildrenCompleteSchoolLivingM" runat="server" Text="<%$ Resources:Resource,L_HHNBChildrenCompleteSchoolLivingM %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHNBChildrenCompleteSchoolLivingM" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHNBChildrenCompleteSchoolLivingF" runat="server" Text="<%$ Resources:Resource,L_HHNBChildrenCompleteSchoolLivingF %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHNBChildrenCompleteSchoolLivingF" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry"  style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHNBChildrenCompleteSchoolLivingTotal" runat="server" Text="<%$ Resources:Resource,L_HHNBChildrenCompleteSchoolLivingTotal %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHNBChildrenCompleteSchoolLivingT" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <hr/>

                <table>
                    <%--6ieme Bloc pour assuré enfant--%>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHNBChildrenDropSchoolLivingM" runat="server" Text="<%$ Resources:Resource,L_HHNBChildrenDropSchoolLivingM %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHNBChildrenDropSchoolLivingM" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHNBChildrenDropSchoolLivingF" runat="server" Text="<%$ Resources:Resource,L_HHNBChildrenDropSchoolLivingF %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHNBChildrenDropSchoolLivingF" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHNBChildrenDropSchoolLivingTotal" runat="server" Text="<%$ Resources:Resource,L_HHNBChildrenDropSchoolLivingTotal %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHNBChildrenDropSchoolLivingT" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <hr/>
                <table>
                    <%--7ieme Bloc pour assuré enfant--%>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHNBGirlsMarried" runat="server" Text="<%$ Resources:Resource,L_HHNBGirlsMarried %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHNBGirlsMarried" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <hr/>
                <table>
                    <%--8ieme Bloc pour assuré enfant--%>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHNBChildrenBirthCertifM" runat="server" Text="<%$ Resources:Resource,L_HHNBChildrenBirthCertifM %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHNBChildrenBirthCertifM" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHNBChildrenBirthCertifF" runat="server" Text="<%$ Resources:Resource,L_HHNBChildrenBirthCertifF %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHNBChildrenBirthCertifF" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHNBChildrenBirthCertifTotal" runat="server" Text="<%$ Resources:Resource,L_HHNBChildrenBirthCertifTotal %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHNBChildrenBirthCertifT" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <hr/>
                <table>
                    <%--9ieme Bloc pour assuré enfant--%>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHHealthStatus" runat="server" Text="<%$ Resources:Resource,L_HHHealthStatus %>">
                            </asp:Label>
                            <asp:DropDownList ID="ddlHHHealthStatus" runat="server" Width="150px"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHExpenditure" runat="server" Text="<%$ Resources:Resource,L_HHExpenditure %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHExpenditure" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHExpenditurePerH" runat="server" Text="<%$ Resources:Resource,L_HHExpenditurePerH %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHExpenditurePerH" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHNutritionalStatus" runat="server" Text="<%$ Resources:Resource,L_HHNutritionalStatus %>">
                            </asp:Label>
                            <asp:DropDownList ID="ddlHHNutritionalStatus" runat="server" Width="150px"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHMentalPhysicalDisability" runat="server" Text="<%$ Resources:Resource,L_HHMentalPhysicalDisability %>">
                            </asp:Label>
                            <asp:DropDownList ID="ddlHHMentalPhysicalDisability" runat="server" Width="150px"/>
                        </td>
                    </tr>
                </table>
                <hr/>
                <table>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHMentalPhysicalDisabilityM" runat="server" Text="<%$ Resources:Resource,L_HHMentalPhysicalDisabilityM %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHMentalPhysicalDisabilityM" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHMentalPhysicalDisabilityF" runat="server" Text="<%$ Resources:Resource,L_HHMentalPhysicalDisabilityF %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHMentalPhysicalDisabilityF" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHMentalPhysicalDisabilityTotal" runat="server" Text="<%$ Resources:Resource,L_HHMentalPhysicalDisabilityTotal %>"/>
    
                            <asp:TextBox ID="txtHHMentalPhysicalDisabilityT" runat="server" CssClass="numbersOnly" MaxLength="12" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <hr/>
                <table>
                    <%--11ieme Bloc pour assuré enfant--%>
                    <tr>
                        <td class="FormLabel" style="white-space:nowrap;">
                            <asp:Label ID="L_HHMentalPhysicalDisabilityObtainable" runat="server" Text="<%$ Resources:Resource,L_HHMentalPhysicalDisabilityObtainable %>"/>
                        </td>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:CheckBox ID="chkHHMentalPhysicalDisabilityO1" runat="server"
                            Text='<%$ Resources:Resource, L_HHMentalPhysicalDisabilityO1 %>'
                            ForeColor="Blue"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:CheckBox ID="chkHHMentalPhysicalDisabilityO2" runat="server"
                            Text='<%$ Resources:Resource, L_HHMentalPhysicalDisabilityO2 %>' 
                            ForeColor="Blue"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:CheckBox ID="chkHHMentalPhysicalDisabilityO3" runat="server"
                            Text='<%$ Resources:Resource, L_HHMentalPhysicalDisabilityO3 %>'
                            ForeColor="Blue"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_HHMentalPhysicalDisabilityO4" runat="server" Text="<%$ Resources:Resource,L_HHMentalPhysicalDisabilityO4 %>">
                            </asp:Label>
                            <asp:TextBox ID="txtHHMentalPhysicalDisabilityO4" runat="server"  Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <hr/>
                <table>
                    <tr id="trFSPRegion" runat="server">
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="lblFSPRegion" runat="server" Text="<%$ Resources:Resource, L_FSPREGION %>"></asp:Label>
                            <asp:DropDownList ID="ddlFSPRegion" runat="server" AutoPostBack="True" Width="150px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfRegionFSP" runat="server" ControlToValidate="ddlFSPRegion" InitialValue="0" SetFocusOnError="True" Style="direction: ltr" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                    Text='*'></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id="trFSPDistrict" runat="server">
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="lblFSPDistrict" runat="server" Text="<%$ Resources:Resource, L_FSPDISTRICT %>"></asp:Label>
                            <asp:DropDownList ID="ddlFSPDistrict" runat="server" AutoPostBack="True" Width="150px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfDistrictFSP" runat="server" ControlToValidate="ddlFSPDistrict" InitialValue="0" SetFocusOnError="True" Style="direction: ltr" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                    Text='*'></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id="trFSPCategory" runat="server">
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="lblFSPCategory" runat="server" Text="<%$ Resources:Resource, L_FSPCATEGORY %>"></asp:Label>
                            <asp:DropDownList ID="ddlFSPCateogory" runat="server" AutoPostBack="True" Width="150px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfFSPCategory" runat="server" ControlToValidate="ddlFSPCateogory" InitialValue="0" SetFocusOnError="True" Style="direction: ltr" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                    Text='*'></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id="trFSP" runat="server">
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="lblFSP" runat="server" Text="<%$ Resources:Resource, L_FSP %>"></asp:Label>
                            <asp:DropDownList ID="ddlFSP" runat="server" Width="150px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfFSP" runat="server" ControlToValidate="ddlFSP" InitialValue="0" SetFocusOnError="True" Style="direction: ltr" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                    Text='*'></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id="trBeneficiary" runat="server">
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_CARD" runat="server" Text="<%$ Resources:Resource,L_CARD%>">
                            </asp:Label>
                            <asp:DropDownList ID="ddlCardIssued" runat="server" Width="150px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfBeneficiary" runat="server" ControlToValidate="ddlCardIssued" InitialValue="" SetFocusOnError="True" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                    Text='*'></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id="trBeneficiary1" runat="server">
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td rowspan="18" valign="top">
                            <asp:UpdatePanel ID="upImage" runat="server">
                                <ContentTemplate>
                                    <asp:Image ID="Image1" runat="server" Width="200px" Height="200px" ImageAlign="Middle" onerror="NoImage(this)" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:Button runat="server" ID="btnBrowse" Text='<%$ Resources:Resource,B_BROWSE%>' />
                        </td>
                    </tr>
                    <tr id="trEmail" runat="server" style="display: none;">
                        <td class="FormLabel">
                            <asp:Label ID="L_EMAIL0" runat="server" Text="<%$ Resources:Resource, L_EMAIL %>"></asp:Label>
                        </td>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:TextBox ID="txtEmail" runat="server" Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfEmail" runat="server" ControlToValidate="txtEmail" SetFocusOnError="True" Text="*" ValidationGroup="check" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                    Text='*'></asp:RegularExpressionValidator>
                        </td>
                        <td>&nbsp;</td>
                        <td class="DataEntry" style="white-space:nowrap;">&nbsp;</td>
                    </tr>
                    <tr id="trConfirmation" runat="server" style="display: none;">
                        <td class="FormLabel">
                            <asp:Label ID="lblConfirmationType" runat="server" Text="<%$ Resources:Resource,L_CONFIRMATIONTYPE %>"></asp:Label>
                        </td>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:DropDownList ID="ddlConfirmationType" runat="server" Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td><asp:RequiredFieldValidator 
                            ID="rfConfirmation" 
                            runat="server" 
                            ControlToValidate="ddlConfirmationType" 
                            InitialValue="" 
                            SetFocusOnError="True" 
                            ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                    Text='*'></asp:RequiredFieldValidator></td>
                        <td class="FormLabel">
                            <asp:Label ID="L_CONFIRMATIONNO" runat="server" style="direction: ltr" Text="<%$ Resources:Resource, L_CONFIRMATIONNO %>"></asp:Label>
                        </td>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:TextBox ID="txtConfirmationNo" runat="server" MaxLength="12" style="direction: ltr" Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator 
                            ID="rfConfirmationNo" 
                            runat="server" 
                            ControlToValidate="txtConfirmationNo" 
                            SetFocusOnError="True" 
                            ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                    Text='*'></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id="trPoverty" runat="server" style="display: none;">
                        <td class="FormLabel"> 
                            <asp:Label ID="lblConfirmationType0" runat="server" Text="<%$ Resources:Resource,L_POVERTY %>"></asp:Label>
                        </td>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:DropDownList ID="ddlPoverty" runat="server" Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfPoverty" runat="server" ControlToValidate="ddlPoverty" InitialValue="" SetFocusOnError="True"  ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                        Text='*'></asp:RequiredFieldValidator>
                        </td>
                        <td class="FormLabel">
                                    &nbsp;</td>
                                <td class="DataEntry">
                                    &nbsp;</td>
                    </tr>
                    <tr id="trType" runat="server" style="display: none;">
                        <td class="FormLabel">
                            <asp:Label ID="L_TYPE" runat="server" Text="<%$ Resources:Resource, L_GROUPTYPE %>"></asp:Label>
                        </td>
                        <td class="DataEntry">
                            <asp:DropDownList ID="ddlType" runat="server" Width="150px" >
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfType" runat="server" 
                                ControlToValidate="ddlType" InitialValue="" SetFocusOnError="True" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                Text='*'></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td class="FormLabel"> <asp:Label ID="lblEthnicity" runat="server" Visible="false" Text='<%$ Resources:Resource,L_ETHNICITY %>'> </asp:Label> </td>
                        <td class="DataEntry">
                            <asp:DropDownList 
                                ID="ddlEthnicity"
                                runat="server"
                                Width="150px" Visible="false" >
                            </asp:DropDownList>
                        </td>
                        <td></td>
                    </tr>

                </table>



                <%--ICI ON VA TRAITER TOUS LE BLOC INFERIEUR DU FORMULAIRE assuré enfant--%>
                <hr/>
                <table>
                    <%-- Tableau 1--%>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_Relationship" runat="server" Text="<%$ Resources:Resource,L_Relationship %>">
                            </asp:Label>
                            <asp:DropDownList ID="ddlRelationship" runat="server" Width="150px"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_ChildName" runat="server" Text="<%$ Resources:Resource,L_ChildName %>">
                            </asp:Label>
                            <asp:TextBox ID="txtChildName" runat="server" MaxLength="100" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_GENDER1" runat="server" Text="<%$ Resources:Resource,L_GENDER %>">
                            </asp:Label>
                            <asp:DropDownList ID="ddlChildGender" runat="server" Width="150px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldGender1" runat="server" ControlToValidate="ddlChildGender" InitialValue="" SetFocusOnError="True" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                    Text='*'></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_BIRTHDATEINCONNU1" runat="server" Text="<%$ Resources:Resource,L_BIRTHDATEINCONNU %>">
                            </asp:Label>
                            <asp:CheckBox ID="chkDateInconnueChild" runat="server" OnCheckedChanged="chkDateInconnueChild_CheckedChanged" onclick="fireCheckChanged()" 
                                ForeColor="Blue"/> 
                        </td>
                    </tr>
                    <tr id="date_naissance_enfant">
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_BIRTHDATE1" runat="server" Text="<%$ Resources:Resource,L_BIRTHDATE %>">
                            </asp:Label>
                            <asp:TextBox ID="txtBirthDateChild" runat="server" Width="132px"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="Button2" TargetControlID="txtBirthDateChild">
                            </asp:CalendarExtender>
                            <asp:Button ID="Button2" runat="server" Height="20px" Width="20px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldBirthDate1" runat="server" ControlToValidate="txtBirthDateChild" SetFocusOnError="False" ValidationGroup="check" ForeColor="Red" Display="Dynamic"
                                    Text='*'></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtBirthDateChild" ErrorMessage="*" SetFocusOnError="false" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/](19|20)\d\d$" ValidationGroup="check" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_CHBirthCertificate" runat="server" Text="<%$ Resources:Resource,L_CHBirthCertificate %>">
                            </asp:Label>
                            <asp:DropDownList ID="ddlCHBirthCertificate" runat="server" Width="150px"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_CHEnrolmentStatus" runat="server" Text="<%$ Resources:Resource,L_CHEnrolmentStatus %>">
                            </asp:Label>
                            <asp:DropDownList ID="ddlCHEnrolmentStatus" runat="server" Width="150px"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_ChildSchoolName" runat="server" Text="<%$ Resources:Resource,L_ChildSchoolName %>">
                            </asp:Label>
                            <asp:TextBox ID="txtChildSchoolName" runat="server" MaxLength="50" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_CHEnrolmentWhichClass" runat="server" Text="<%$ Resources:Resource,L_CHEnrolmentWhichClass %>">
                            </asp:Label>
                            <asp:DropDownList ID="ddlCHEnrolmentWhichClass" runat="server" Width="150px"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_CHEnrolmentScore" runat="server" Text="<%$ Resources:Resource,L_CHEnrolmentScore %>">
                            </asp:Label>
                            <asp:DropDownList ID="ddlCHEnrolmentScore" runat="server" Width="150px"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_CHEnrolmentOutofSchool" runat="server" Text="<%$ Resources:Resource,L_CHEnrolmentOutofSchool %>">
                            </asp:Label>
                            <asp:DropDownList ID="ddlCHEnrolmentOutofSchool" runat="server" Width="150px"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" style="white-space:nowrap;" ID="L_CHParentalStatus" runat="server" Text="<%$ Resources:Resource,L_CHParentalStatus %>">
                            </asp:Label>
                            <asp:DropDownList ID="ddlCHParentalStatus" runat="server" Width="150px"/>
                        </td>
                    </tr>
                    
                </table>
                <hr/>
                <table>
                    <%--Tableau 2--%>
                    <tr>
                        <td class="FormLabel" style="white-space:nowrap;">
                            <asp:Label ID="L_ResidentialStatus" runat="server" Text="<%$ Resources:Resource,L_ResidentialStatus %>">
                            </asp:Label>
                        </td>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:CheckBox ID="chkResidentialStatus1" runat="server"
                            Text='<%$ Resources:Resource, L_ResidentialStatus1 %>'
                            ForeColor="Blue"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:CheckBox ID="chkResidentialStatus2" runat="server"
                            Text='<%$ Resources:Resource, L_ResidentialStatus2 %>' 
                            ForeColor="Blue"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:CheckBox ID="chkResidentialStatus3" runat="server"
                            Text='<%$ Resources:Resource, L_ResidentialStatus3 %>' 
                            ForeColor="Blue"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:CheckBox ID="chkResidentialStatus4" runat="server"
                            Text='<%$ Resources:Resource, L_ResidentialStatus4 %>' 
                            ForeColor="Blue"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:CheckBox ID="chkResidentialStatus5" runat="server"
                            Text='<%$ Resources:Resource, L_ResidentialStatus5 %>' 
                            ForeColor="Blue"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:CheckBox ID="chkResidentialStatus6" runat="server"
                            Text='<%$ Resources:Resource, L_ResidentialStatus6 %>' 
                            ForeColor="Blue"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:CheckBox ID="chkResidentialStatus7" runat="server"
                            Text='<%$ Resources:Resource, L_ResidentialStatus7 %>' 
                            ForeColor="Blue"/>
                        </td>
                    </tr>
                </table>
                <hr/>
                <table>
                    <%--Tableau 3--%>
                    <tr>
                        <td class="FormLabel" style="white-space:nowrap;">
                            <asp:Label ID="L_CHSpecialNeeds" runat="server" Text="<%$ Resources:Resource,L_CHSpecialNeeds %>">
                            </asp:Label>
                        </td>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:CheckBox ID="chkCHSpecialNeeds1" runat="server"
                            Text='<%$ Resources:Resource, L_CHSpecialNeeds1 %>'
                            ForeColor="Blue"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:CheckBox ID="chkCHSpecialNeeds2" runat="server"
                            Text='<%$ Resources:Resource, L_CHSpecialNeeds2 %>'
                            ForeColor="Blue"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:CheckBox ID="chkCHSpecialNeeds3" runat="server"
                            Text='<%$ Resources:Resource, L_CHSpecialNeeds3 %>'
                            ForeColor="Blue"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:CheckBox ID="chkCHSpecialNeeds4" runat="server"
                            Text='<%$ Resources:Resource, L_CHSpecialNeeds4 %>'
                            ForeColor="Blue"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:CheckBox ID="chkCHSpecialNeeds5" runat="server"
                            Text='<%$ Resources:Resource, L_CHSpecialNeeds5 %>'
                            ForeColor="Blue"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="DataEntry" style="white-space:nowrap;">
                            <asp:Label class="FormLabel" ID="L_CHSpecialNeeds6" runat="server" Text="<%$ Resources:Resource,L_CHSpecialNeeds6 %>">
                            </asp:Label>
                            <asp:TextBox ID="txtCHSpecialNeeds6" runat="server"  Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <hr/>
            </ContentTemplate>
        </asp:Panel>
    </asp:Panel>
   </div>
   <asp:Panel ID="pnlButtons" runat="server"   CssClass="panelbuttons" >
                <table width="100%" cellpadding="10 10 10 10">
                 <tr>
                        
                         <td align="left" >
                        
                               <asp:Button 
                            
                            ID="B_SAVE" 
                            runat="server" 
                            Text='<%$ Resources:Resource,B_SAVE%>'
                            ValidationGroup="check"  />
                        </td>
                        
                        
                        <td  align="right">
                       <asp:Button 
                            
                            ID="B_CANCEL" 
                            runat="server" 
                            Text='<%$ Resources:Resource,B_CANCEL%>'
                              />
                        </td>
                        
                    </tr>
                </table>   
                 <asp:HiddenField ID="hfInsureeIsOffline" runat="server" Value="" />
               <asp:HiddenField ID="hfFamilyIsOffline" runat="server" Value="" />
                    </asp:Panel>
</asp:Content>
