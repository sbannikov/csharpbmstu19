<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmissionsWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Список полученных от датчиков измерений</h1>

    <table id="valuesTable" class="table table-hover">
        <thead>
            <tr>
                <th>Датчик</th>
                <th>Параметр</th>
                <th>Значение</th>
                <th>Метка времени</th>
            </tr>
        </thead>
        <tbody id="valuesTableBody"></tbody>
    </table>

    <script type="text/javascript">
        const
            apiUrlPrefix = 'api/Measurements',
            receivedIds = [],
            apiRequestHeaders = {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            };

        const processError = (err, url) => {
            console.err(`Ошибка при при запросе на сервер по адресу ${url}`);
            console.err(err);
        };

        const getById = (id) => {
            const apiUrl = `${apiUrlPrefix}/${id}`;

            fetch(apiUrl, { headers: apiRequestHeaders })
                .then(response => response.json())
                .then(data => {
                    if (data === null) {
                        return;
                    }

                    let tableClass;
                    switch (data.value) {
                        case 'OK':
                            tableClass = 'success';
                            break;
                        case 'ERROR':
                            tableClass = 'danger';
                            break;
                        case 'MAINTENANCE':
                            tableClass = 'info';
                            break;
                        default:
                            tableClass = '';
                            break;
                    }

                    const
                        tableBody = document.getElementById('valuesTableBody'),
                        formattedDateTime = new Date(data.timestampEnd * 1000).toLocaleString();
                    newDataRow = `<tr class="${tableClass}"><td>${data.sensorUuid}</td><td>${data.code}</td><td>${data.value}</td><td>${formattedDateTime}</td></tr>`;

                    tableBody.innerHTML += newDataRow;
                })
                .catch(error => processError(error, apiUrl));
        }

        function getAllIds() {
            const apiUrl = apiUrlPrefix;

            fetch(apiUrl, { headers: apiRequestHeaders })
                .then(response => response.json())
                .then(data => {
                    if (!Array.isArray(data)) {
                        throw new TypeError('Список id должен быть массивом');
                    }

                    data.forEach(id => {
                        if (receivedIds.indexOf(id) === -1) {
                            receivedIds.push(id);
                            getById(id);
                        }
                    });

                    setTimeout(getAllIds, 10000);
                })
                .catch(error => processError(error, apiUrl));
        }

        getAllIds();
    </script>
</asp:Content>
