<%@ page title="Nova Tarefa" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="Create.aspx.cs" inherits="Pessoal.WebForms.Tarefas.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Nova Tarefa</h1>
    <hr />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <table>
        <tr>
            <td class="modal-sm" style="width: 150px">Nome</td>
            <td>
                <asp:TextBox ID="nomeTextBox" runat="server" Width="232px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nome é Obrigatório" CssClass="text-danger" ControlToValidate="nomeTextBox">(!)</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 150px">Prioridade</td>
            <td>
                <asp:DropDownList ID="prioridadeDropDownList" runat="server" DataSourceID="prioridadesObjectDataSource" AppendDataBoundItems="true" Width="238px">
                    <asp:ListItem Text="Selecione" Value="0" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Selecione a prioridade" ControlToValidate="prioridadeDropDownList" CssClass="text-danger" InitialValue="0">(!)</asp:RequiredFieldValidator>
                <asp:ObjectDataSource ID="prioridadesObjectDataSource" runat="server" SelectMethod="ObterPrioridades" TypeName="Pessoal.WebForms.Tarefas.Create"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 150px">Concluída</td>
            <td>
                <asp:CheckBox ID="concluidaCheckBox" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 150px">Observações</td>
            <td>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="observacoesTextBox" Rows="5" Width="251px"/>
            </td>
        </tr>
    </table>
    <asp:Button Text="Gravar" ID="gravarButton" runat="server" OnClick="gravarButton_Click" />
</asp:Content>
