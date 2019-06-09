
 
$(document).ready(function () {

    //搜尋視窗------
    $("#search_book_category").kendoDropDownList({
        optionLabel: "請選擇...",
        dataTextField: "text",
        dataValueField: "value",
        dataSource: "",
    });

    $("#search_book_keeper").kendoDropDownList({
        optionLabel: "請選擇...",
        dataTextField: "text",
        dataValueField: "value",
        dataSource: "",
    });

    $("#search_book_status").kendoDropDownList({
        optionLabel: "請選擇...",
        dataTextField: "text",
        dataValueField: "value",
        dataSource: "",
    });
    //------

    //新增視窗------
    $("#save_book").click(function () {
        $("#add_window").data("kendoWindow").center().open();
    });

    $("#add_window").kendoWindow({
        width: "600",
        title: "新增書籍",
        visible: false,
        actions: [
            "Pin",
            "Minimize",
            "Maximize",
            "Close"
        ],
    });

    $("#add_bought_datepicker").kendoDatePicker({
        format: 'yyyy-MM-dd',
        value: new Date(),
    });

    $("#add_book_category").kendoDropDownList({
        optionLabel: "請選擇...",
        dataTextField: "text",
        dataValueField: "value",
        dataSource: "",
    });
    //------
});
