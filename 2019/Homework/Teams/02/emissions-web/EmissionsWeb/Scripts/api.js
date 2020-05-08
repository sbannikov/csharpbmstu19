var apiUrlPrefix = 'api/Measurements', receivedIds = [], apiRequestHeaders = {
    'Accept': 'application/json',
    'Content-Type': 'application/json'
};
var processError = function (err, url) {
    console.error("\u041E\u0448\u0438\u0431\u043A\u0430 \u043F\u0440\u0438 \u043F\u0440\u0438 \u0437\u0430\u043F\u0440\u043E\u0441\u0435 \u043D\u0430 \u0441\u0435\u0440\u0432\u0435\u0440 \u043F\u043E \u0430\u0434\u0440\u0435\u0441\u0443 " + url);
    console.error(err);
};
;
var getById = function (id) {
    var apiUrl = apiUrlPrefix + "/" + id;
    fetch(apiUrl, { headers: apiRequestHeaders })
        .then(function (response) { return response.json(); })
        .then(function (data) {
        if (data === null) {
            return;
        }
        var tableBody = document.getElementById('valuesTableBody'), newDataRow = "<tr><td>" + data.sensorUuid + "</td><td>" + data.code + "</td><td>" + data.value + "</td><td>" + data.timestampEnd + "</td></tr>";
        tableBody.innerHTML += newDataRow;
    })
        .catch(function (error) { return processError(error, apiUrl); });
};
function getAllIds() {
    var apiUrl = apiUrlPrefix;
    fetch(apiUrl, { headers: apiRequestHeaders })
        .then(function (response) { return response.json(); })
        .then(function (data) {
        if (data === null) {
            return;
        }
        if (!Array.isArray(data)) {
            throw new TypeError('Список id должен быть массивом');
        }
        data.forEach(function (id) {
            if (receivedIds.indexOf(id) === -1) {
                receivedIds.push(id);
                getById(id);
            }
        });
        setTimeout(getAllIds, 10000);
    })
        .catch(function (error) { return processError(error, apiUrl); });
}
getAllIds();
//# sourceMappingURL=api.js.map