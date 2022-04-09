const url = `/api/Ann`;
async function GetAnnouncementsList() {
    const response = await fetch(url, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const anns = await response.json();
        let tBody = document.querySelector("tbody");
        while (tBody.lastElementChild){
            tBody.removeChild(tBody.lastElementChild);
        }

        let counter = 0;
        anns.forEach(item => {
            counter++;

            let newEditBtn = document.createElement("button");
            newEditBtn.classList.add(`btn`);
            newEditBtn.classList.add(`btn-outline-primary`);
            newEditBtn.innerText = 'Edit';
            newEditBtn.addEventListener("click", () => EditAnnouncement(item.id));

            const deleteBtn = document.createElement("button");
            deleteBtn.classList.add(`btn`);
            deleteBtn.classList.add(`btn-outline-danger`);
            deleteBtn.innerText = 'Delete';
            deleteBtn.addEventListener("click", ()=>DeleteAnnouncement(item.id));

            let tr = tBody.insertRow();
            tr.classList.add("items");

            let th = tr.insertCell(0);
            th.className = "counter";
            th.append(`${counter}`);

            let td1 = tr.insertCell(1);
            td1.append(`${item.title}`);
            td1.addEventListener("click", () => DisplayAnnouncementInfo(item.id));

            let td2 = tr.insertCell(2);
            td2.appendChild(newEditBtn);

            let td3 = tr.insertCell(3);
            td3.appendChild(deleteBtn);

            tBody.append(tr);
        });
    }
}

async function DisplayAnnouncementInfo(id) {


    const response = await fetch(`${url}/${id}`, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const ann = await response.json();

        annId.value = id;
        let modalTitle = document.getElementById("infoModalLabel");
        modalTitle.innerText = `${ann.title}`;

        let modalDescription = document.getElementById("infoModalDescription");
        modalDescription.innerText = `${ann.description}`;

        announcementDate.innerText = `${ann.createdDate.split('T')[0]}`;

        let infoModal = new bootstrap.Modal(document.getElementById('infoModal'));

        editBtn.addEventListener("click", () => infoModal.hide());

        let similar = document.getElementById("similarTable");
        if(similar.firstChild)
        {
            similar.firstChild.remove();
        }

        let counter = 0;
        ann.similarAnnouncements.forEach(item => {
            counter++;

            let tr = similar.insertRow();

            let td = tr.insertCell(0);
            td.className = "counter";
            td.append(`${counter}`);

            let td1 = tr.insertCell(1);
            td1.classList.add("text-center");
            td1.append(`${item.title}`);
            td1.addEventListener("click", () => infoModal.hide());
            td1.addEventListener("click", () => DisplayAnnouncementInfo(item.id));
        });
        infoModal.show();

    }
}

async function EditAnnouncement(defaultId) {

    let annId = document.getElementById("annId");
  
    const response = await fetch(`${url}/${defaultId===undefined?annId.value:defaultId}`, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const ann = await response.json();

        let editModal = new bootstrap.Modal(document.getElementById('editModal'));

        let titleField = document.getElementById("editTitle");
        titleField.value = `${ann.title}`;

        let descriptionField = document.getElementById("editDescription");
        descriptionField.value = `${ann.description}`;

        let annDate = document.getElementById("announcementDate1");
        
        annDate.innerText = `${ann.createdDate.split('T')[0]}`;

         const saveBtn = document.getElementById("announcementDate1").nextElementSibling;
         saveBtn.addEventListener("click",()=>editModal.hide());

        annId.value = ann.id;
        editModal.show();
    }
}

async function SaveEditingAnnouncement() {

    const annId = document.getElementById("annId");
     const announcement = {
        id: annId.value,
        title: document.getElementById("editTitle").value,
        description: document.getElementById("editDescription").value
    }

    const response = await fetch(`${url}/${annId.value}?title=${announcement.title}&description=${announcement.description}`, {
        method: 'PUT'
    }).then(()=>GetAnnouncementsList());
}

async function DeleteAnnouncement(deleteAnnId){
    let annId = document.getElementById("annId").value;
    await fetch(`${url}/${deleteAnnId===undefined?annId:deleteAnnId}`,{
        method: 'DELETE'
    }).then(()=>GetAnnouncementsList());
    
}


async function CreateAnnouncement()
{
    const newAnn ={
        title: document.getElementById("titleField").value,
        description: document.getElementById("descriptionField").value
    };
    await fetch(`${url}?title=${newAnn.title}&description=${newAnn.description}`,
        {
            method: "POST"
        }).then(()=>GetAnnouncementsList());
    
}

