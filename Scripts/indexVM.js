const pqOptions = {
    width: 1109,
    height: 500,
    showTitle: false,
    showHeader: true,
    showTop: true,
    showToolbar: false,
    showBottom: true,
    wrap: true,
    hwrap: false,
    sortable: false,
    editable: false,
    resizable: true,
    collapsible: { on: true, collapsed: false },
    draggable: true, dragColumns: { enabled: true },
    scrollModel: { autoFit: true },
    numberCell: { show: false, resizable: true, title: "S.N.", minWidth: 30 },
    pageModel: { curPage: 1, rPP: 10, type: "local" },
    columnTemplate: { wrap: true, editable: true, dataType: "string", halign: "center", hvalign: "center", resizable: true, styleHead: { 'font-weight': "bold" } },
};

function IndexVM() {
    const self = this;

    var isNullOrEmpty = function (str) {
        if (str === undefined || str === null) {
            return true;
        } else if (typeof str === "string") {
            return (str.trim() === "");
        } else {
            return false;
        }
    };

    const models = {
        MyModel: function (item) {
            item = item || {};
            this.Name = ko.observable(item.Name || "");
            this.Category = ko.observable(item.Category || "");
           
            this.quantity = ko.observable(item.quantity || "");
            this.CreatedBy = ko.observable(item.CreatedBy || "");
           
            this.Email=ko.observable(item.Email ||"");
            this.Mobile=ko.observable(item.Mobile ||"");
        },
        UiElements: function () {
            self.MyModel = ko.observable(new models.MyModel());
            self.DataList = ko.observableArray([]);
            
        },
    };

    self.SaveInformation = function () {

        if (UiEvents.validate.SaveValidation()) {
            UiEvents.functions.Save();
        }
    };

    self.deleteRow = function (id) {
        UiEvents.functions.Delete(id);
    };

    const UiEvents = {
        validate: {
            SaveValidation: function () {
                if (isNullOrEmpty(self.MyModel().Name())) {
                    alert("Warning! - First Name cannot be empty...!!!");
                    return false;
                }
                else if (isNullOrEmpty(self.MyModel().Category())) {
                    alert("Warning! - Last Name cannot be empty...!!!");
                    return false;
                }
                else if (isNullOrEmpty(self.MyModel().Quantity())) {
                    alert("Warning! - Date of birth cannot be empty....!!");
                    return false;
                }
               
                
                else if (isNullOrEmpty(self.MyModel().CreatedBy())) {
                    alert("Warning! - Gender cannot be empty...!!!");
                    return false;
                }
                else {

                   
                    self.DataList.push(ko.toJS(self.MyModel()));
                    return true;
                }
            }
        },
        clear: {
            ResetAll: function () {
                self.MyModel(new models.MyModel());
                self.DataList([]);
            },
        },
        functions: {
            Save: function () {

                if ($("#demoGrid").pqGrid("instance")) {
                    $("#demoGrid").pqGrid('option', 'dataModel.data', ko.toJS(self.DataList()));
                    $("#demoGrid").pqGrid('refreshDataAndView');
                }
                else {
                    const options = Object.assign({}, pqOptions);
                    options.colModel = [
                        { title: "Address", align: "center", dataIndx: "Name", width: "30%" },
                        { title: "Street Name", align: "center", dataIndx: "Category", width: "30%" },
                        { title: "House No.", align: "center", dataIndx: "Quantity", width: "30%" },
                        {
                            title: "Action", align: "center", render: function (ui) {
                                return `<button type='button' title='Delete' onclick='obj.deleteRow("${ui.rowIndx}")'>Delete</button>`
                            }, width: "10%"
                        },
                    ];
                    options.dataModel = { data: ko.toJS(self.DataList()) };
                    $("#demoGrid").pqGrid(options);
                }
            },
            Delete: function (index) {
                self.DataList.splice(index, 1);
                UiEvents.functions.Save();
            },
        },

    };

    function Init() {
        models.UiElements();
        UiEvents.clear.ResetAll();
        UiEvents.functions.Save();
    }
    Init();
}

var obj;

$(document).ready(function () {
    obj = new IndexVM();
    ko.applyBindings(obj);

});