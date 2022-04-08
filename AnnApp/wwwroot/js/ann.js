        async function GetAnnouncementsList() {
            const response = await fetch("/api/Ann", {
                method: "GET",
                headers: { "Accept": "application/json" }
            });
            if (response.ok === true) {
                const anns = await response.json();
                let tBody = document.querySelector("tbody");
               
                let counter = 0; 
                anns.forEach(item => {
                    counter++;

                    const editBtn = document.createElement("button");
                    editBtn.classList.add(`btn`);
                    editBtn.classList.add(`btn-outline-primary`);
                    editBtn.innerText = 'Edit';
                    editBtn.addEventListener("click",()=>console.log(item.id));
                    //editBtn.addEventListener("click", myModal.toggle());
                    //editBtn.setAttribute('onclick', `AnnouncementInfo(${item.id})`);

                    const deleteBtn = document.createElement("button");
                    deleteBtn.classList.add(`btn`);
                    deleteBtn.classList.add(`btn-outline-danger`);
                    deleteBtn.innerText = 'Delete';
                    //deleteBtn.setAttribute('data-bs-target','#myModal');
                    //deleteBtn.setAttribute(`onclick`,`AnnouncementInfo(${item.id})`);
                    //deleteBtn.setAttribute('onclick', `displayDeleteForm(${item.id})`);

                    let tr = tBody.insertRow();
                    tr.classList.add("items");
                    
                    let th = tr.insertCell(0);
                    th.className = "counter";
                    th.append(`${counter}`);

                    let td1 = tr.insertCell(1);
                    td1.append(`${item.title}`);
                    td1.addEventListener("click", ()=>DisplayAnnouncementInfo(item.id));

                    let td2 = tr.insertCell(2);
                    td2.appendChild(editBtn);
                    
                    let td3 = tr.insertCell(3);
                    td3.appendChild(deleteBtn);
                                      
                    tBody.append(tr);
                });
            }
        }

         async function DisplayAnnouncementInfo(id){
            

            const response = await fetch(`/api/Ann/${id}`, {
                method: "GET",
                headers: { "Accept": "application/json" }
            });
            if (response.ok === true) {
                 const ann = await response.json();

                let modalTitle = document.getElementById("infoModalLabel");
                modalTitle.innerText = `${ann.title}`;

                let modalDescription = document.getElementById("infoModalDescription");
                modalDescription.innerText = `${ann.description}`;

                let annDate = document.getElementById("announcementDate");
                annDate.innerText = `${ann.createdDate.split('T')[0]}`;
                
                let myModal = new bootstrap.Modal(document.getElementById('infoModal'), {
                    keyboard: false 
                  });

                let similar = document.getElementById("similarTable");
                similar.firstChild.remove();

                let counter = 0 ;
                ann.similarAnnouncements.forEach(item=>{
                    counter++;
                    
                    let tr = similar.insertRow();

                    let td = tr.insertCell(0);
                    td.className = "counter";
                    td.append(`${counter}`);

                    let td1 = tr.insertCell(1);
                    td1.classList.add("text-center");
                    td1.append(`${item.title}`);
                    td1.addEventListener("click",()=>myModal.hide());
                    td1.addEventListener("click", ()=>DisplayAnnouncementInfo(item.id));
                });
                  myModal.toggle();   
            }
        }

        async function EditAnnouncement(id,title,description)
        {
            const response = await fetch(`/api/Ann/${id}`, {
                headers: { "Accept": "application/json", "Content-Type": "application/json" },
                body: JSON.stringify({
                        id: annId,
                        title: Title,
                        description: Description
                        })
            });
            if (response.ok === true) {

            }
        }
        
            
            