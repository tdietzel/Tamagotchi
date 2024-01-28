// function applyItem(itemId, petId, itemType) {
//   fetch(`/pets/applyItem`, {
//     method: 'POST',
//     headers: {
//       'Content-Type': 'application/json',
//     },
//     body: JSON.stringify({ itemId, petId, itemType }),
//   })
//   .then(response => response.json())
//   .then(data => {
//     if (data.success) {
//       // Remove the item from the inventory UI
//       document.querySelector(`button[data-item-id='${itemId}'][data-pet-id='${petId}']`).remove();

//       // Optionally, update the pet's status on the page
//       // This could involve changing the display of pet's fullness, energy, etc.
//       // updatePetStatus(petId); // You need to define this function

//       // Optionally, display a success message
//       alert('Item applied successfully!');
//     } else {
//       // Handle failure
//       alert('Failed to apply item to pet');
//     }
//   })
//   .catch((error) => {
//     console.error('Error:', error);
//     alert('An error occurred while applying the item.');
//   });
// }