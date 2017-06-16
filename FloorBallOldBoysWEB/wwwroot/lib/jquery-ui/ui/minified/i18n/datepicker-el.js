/*! jQuery UI - v1.12.1 - 2016-09-15
* http://jqueryui.com
* Copyright jQuery Foundation and other contributors; Licensed  */
!function(a) {
    "function" == typeof define && define.amd ? define(["../widgets/datepicker"], a) : a(jQuery.datepicker)
}(function(a) {
    return a.regional.el =
    {
        closeText: "Κλείσιμο",
        prevText: "Προηγούμενος",
        nextText: "Επόμενος",
        currentText: "Σήμερα",
        monthNames: [
            "Ιανουάριος", "Φεβρουάριος", "Μάρτιος", "Απρίλιος", "Μάιος", "Ιούνιος", "Ιούλιος", "Αύγουστος",
            "Σεπτέμβριος", "Οκτώβριος", "Νοέμβριος", "Δεκέμβριος"
        ],
        monthNamesShort: ["Ιαν", "Φεβ", "Μαρ", "Απρ", "Μαι", "Ιουν", "Ιουλ", "Αυγ", "Σεπ", "Οκτ", "Νοε", "Δεκ"],
        dayNames: ["Κυριακή", "Δευτέρα", "Τρίτη", "Τετάρτη", "Πέμπτη", "Παρασκευή", "Σάββατο"],
        dayNamesShort: ["Κυρ", "Δευ", "Τρι", "Τετ", "Πεμ", "Παρ", "Σαβ"],
        dayNamesMin: ["Κυ", "Δε", "Τρ", "Τε", "Πε", "Πα", "Σα"],
        weekHeader: "Εβδ",
        dateFormat: "dd/mm/yy",
        firstDay: 1,
        isRTL: !1,
        showMonthAfterYear: !1,
        yearSuffix: ""
    }, a.setDefaults(a.regional.el), a.regional.el
});