const folderName = $("#Fname");
const folderContent = $("#Fcontent")

//fetch the folder content info.
function getFolderContent(path) {
    fetch('/api/Directory/' + path)
      .then(function (response) {
        return response.json();
    }).then(function (result) {
        folderName.text(result.name);     //folder name as heading
        folderContent.empty();            //empty the content div element
        fillContentDiv(result.folders);   //fill content div with folders
        fillContentDiv(result.files);     //fill content div with files
    }).catch(function (error) {
        console.error("Failed to fetch folder contents:", error);
    });
}

//loop through the list and fill the content div element
function fillContentDiv(list) {
    if (!list) return;                    //return if list is empty
    for (const item of list) {
        const fdiv = document.createElement('div');
        const fname = document.createElement('p');
        fname.textContent = item.name;
        const ftype = document.createElement('p');
        ftype.textContent = item.type;
        fdiv.appendChild(fname);
        fdiv.appendChild(ftype);
        folderContent.append(fdiv);
    }
}


getFolderContent("");