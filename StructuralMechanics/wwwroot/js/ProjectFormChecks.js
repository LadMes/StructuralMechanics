function structureTypeChanged(structureType) {
    var select = document.getElementById("structureTypes");
    var value = parseInt(select.options[select.selectedIndex].value);
    if (isNaN(value)) {
        document.getElementById("thinWalledStructure").style.display = "none";
    }
    else if (value === structureType) {
        document.getElementById("thinWalledStructure").style.display = "flex";
    }
    else {
        document.getElementById("thinWalledStructure").style.display = "none";
    }
}