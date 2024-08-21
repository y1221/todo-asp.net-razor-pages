function changeCategoryFilter(id) {
    // 一度全てのカテゴリから選択中レイアウトを削除
    var categories = document.getElementById('category-list').children;
    for (let i = 0; i < categories.length; i++) {
        categories[i].classList.remove('selected')
    }

    // 選択されたカテゴリに選択中レイアウトを付与
    var target = document.getElementById(id);
    target.classList.add('selected');
}
