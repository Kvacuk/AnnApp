        async function GetAnnouncementsList() {
            // отправляет запрос и получаем ответ
            const response = await fetch("/api/Ann", {
                method: "GET",
                headers: { "Accept": "application/json" }
            });
            // если запрос прошел нормально
            if (response.ok === true) {
                // получаем данные
                const anns = await response.json();
                let tBody = document.querySelector("tbody");
               
                
                let counter = 0; 
                anns.forEach(item => {
                    counter++;

                    const editBtn = document.createElement("button");
                    editBtn.classList.add(`btn`);
                    editBtn.classList.add(`btn-outline-primary`);
                    editBtn.innerText = 'Edit';
                    //editBtn.setAttribute('onclick', `displayEditForm(${item.id})`);

                    const deleteBtn = document.createElement("button");
                    deleteBtn.classList.add(`btn`);
                    deleteBtn.classList.add(`btn-outline-danger`);
                    deleteBtn.innerText = 'Delete';
                    //deleteBtn.setAttribute('onclick', `displayDeleteForm(${item.id})`);


                    let tr = tBody.insertRow();
                    tr.classList.add(`btn`);
                    tr.classList.add(`items`);
                    tr.setAttribute(`onclick`,`AnnouncementInfo(${item.Id})`);
                    
                    let th = tr.insertCell(0);
                    th.className = "counter";
                    th.append(`${counter}`);

                    let td1 = tr.insertCell(1);
                    td1.append(`${item.title}`);

                    let td2 = tr.insertCell(2);
                    td2.appendChild(editBtn);

                    let td3 = tr.insertCell(3);
                    td3.appendChild(deleteBtn);

                    
                    //const td1 = document.createElement("td");
                    //const th = document.createElement("th");
                    //th.append(`${counter}`);
                    //td1.append();
                    //tr.append(th);
                    //tr.append(td1);

                    
                    
                                       
                    // добавляем полученные элементы в таблицу
                    tBody.append(tr);
                });
            }
        }

        async function AnnouncementInfo(Id){
            const response = await fetch(`/api/Ann/${Id}`, {
                method: "GET",
                headers: { "Accept": "application/json" }
            });
            // если запрос прошел нормально
            if (response.ok === true) {
                // получаем данные
                const ann = await response.json();
                let tBody = document.querySelector("tbody");

                var myModal = new bootstrap.Modal(document.getElementById('myModal'), {
                    keyboard: false
                  })
                  myModal.Show();
            }
        }

        
        
            
            