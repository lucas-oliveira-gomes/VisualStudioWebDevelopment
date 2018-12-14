<%@ page title="" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="Create.aspx.cs" inherits="Pessoal.WebForms.Tarefas.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Nova Tarefa</h1>
    <hr />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <table>
        <tr>
            <td style="width: 89px">Nome</td>
            <td>
                <asp:TextBox ID="nomeTextBox" runat="server" Width="109px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nome é obrigatório" CssClass="text-danger" ControlToValidate="nomeTextBox">(!)</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 89px">Prioridade</td>
            <td>
                <asp:DropDownList ID="prioridadeDropDownList" DataSourceID="prioridadesObjectDataSource" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Text="Selecione" Value="" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Selecione a prioridade." ControlToValidate="prioridadeDropDownList" CssClass="text-danger" InitialValue="0" Text="(!)"></asp:RequiredFieldValidator>
                <asp:ObjectDataSource ID="prioridadesObjectDataSource" runat="server" SelectMethod="ObterPrioridade" TypeName="Pessoal.WebForms.Tarefas.Create"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 89px">Concluida</td>
            <td>
                <asp:CheckBox Text="" ID="concluidaCheckBox" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 89px">Observações</td>
            <td>
                <asp:TextBox TextMode="MultiLine" ID="observacoesTextBox" Rows="5" runat="server" Width="240px" />
            </td>
        </tr>
    </table>
    <asp:Button Text="Gravar" ID="gravarButton" runat="server" OnClick="gravarButton_Click" />
</asp:Content>
