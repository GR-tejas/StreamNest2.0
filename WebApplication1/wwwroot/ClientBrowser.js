const folderName = $("#Fname");
const folderContent = $("#Fcontent");
let currentPath = "";

//fetch the folder content info.
function getFolderContent(name = "") {

    if (name !== "") {
        if (currentPath === "") {
            currentPath = name;
        }
        else {
            currentPath += '/' + name;
        }
    }

    fetch('/api/Directory/' + currentPath)
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
        const fbutton = document.createElement('button');
        Object.assign(fbutton, {
            type: 'button',
            name: item.name,
            className: item.type,
            textContent: item.name
        });

        fbutton.addEventListener("click",function () {
            if (this.className === "Folder") {
                console.log("This is a folder");
                getFolderContent(this.name, this.className);
            }
            if (this.className === "File") {

                console.log("This is a file");

                let filePath;

                if (currentPath === "") {
                    filePath = this.name;
                }
                else {
                    filePath = currentPath + "/" + this.name;
                }

                console.log("Opening:", filePath);

                window.open(
                    "/api/Media/" + filePath,
                    "_blank"
                );
            }
        })
        fdiv.appendChild(fbutton);
        folderContent.append(fdiv);
    }
}



getFolderContent();