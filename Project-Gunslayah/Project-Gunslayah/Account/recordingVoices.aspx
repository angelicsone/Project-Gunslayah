<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="recordingVoices.aspx.cs" Inherits="Project_Gunslayah.Account.recordingVoices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

     <h2>Enrollment of voice</h2>
    <hr />

    <p>Please Take Note : Make sure all the .wav files are stored under C:\MyWavFile</p>
    <hr />
    <p>Step 1: Download a voice recorder that can record and save a .wav file </p>
    <asp:Button ID="Button1" runat="server" OnClick="voiceEnrollment1" Text="Enrollment1" />
</asp:Content>

