function showHiddenMenu(menuId, btnId) {
    var hiddenMenu = document.getElementById(menuId);
    var liMenu = document.getElementById(btnId);
    var btnMenu = liMenu.firstElementChild;
    if (hiddenMenu.style.display == "none") {
        hiddenMenu.style.display = "flex";
        liMenu.style.backgroundColor = "var(--color-header-background)";
        btnMenu.style.color = "white";
    }
    else {
        hiddenMenu.style.display = "none";
        liMenu.style.background = "none";
        btnMenu.removeAttribute("style");
    }
}