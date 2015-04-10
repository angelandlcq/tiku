<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dictView.aspx.cs" Inherits="TiKu.Admin._base.dictView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看字典信息-<%=WebName%></title>
    <style type="text/css">
        html, body, input, form, div, span, b, i, p, table, tbody, tr, th, tfoot {
            margin: 0;
            padding: 0;
        }

        body {
            font-size: 14px;
            font-family: 'Microsoft YaHei';
        }

        #container {
            margin: 20px auto;
            width: 400px;
        }

            #container table {
                border: 0;
                border-collapse: collapse;
                width: 100%;
            }

                #container table th {
                    background-color: #F0F5F7;
                }

                #container table td, #container table th {
                    padding: 4px 6px;
                    border: solid 1px #cfcfcf;
                    border-collapse: collapse;
                }

                #container table tr {
                    border: solid 1px #cfcfcf;
                }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <th width="100px">名（Key)</th>
                    <th width="200px">值（Value)</th>
                </tr>
                <%foreach (System.Collections.Generic.KeyValuePair<string, object> item in dictData)
                  {%>
                <tr>
                    <td><%=item.Key%></td>
                    <td><%=item.Value%></td>
                </tr>
                <%}%>
            </table>
        </div>
    </form>
</body>
</html>
